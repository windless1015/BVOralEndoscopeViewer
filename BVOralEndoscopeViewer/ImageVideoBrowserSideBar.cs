using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.Drawing.Imaging;
using Accord.Video.FFMPEG;

namespace BVOralEndoscopeViewer
{
    enum FileTypeEnum
    {
        IMAGE = 0,
        VIDEO = 1,
        UNKNOWN_TYPE = -1
    }

    public partial class ImageVideoBrowserSideBar : UserControl
    {
        //当前本控件显示的视频和图像的路径
        public string FileDataPath { set; get; }
        //存放需要排列的文件的列表信息
        private FileInfoList fileList;

        public delegate void DisplaySelectedItemHandler(string path, string extension);
        //声明事件,用户双击一个item触发显示这个item的.
        public event DisplaySelectedItemHandler DisplaySelectedItem;

        public ImageVideoBrowserSideBar()
        {
            InitializeComponent();
        }

        //双击打开文件,触发外部事件
        private void ImgVideoListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo itemInfo = ImgVideoListView.HitTest(e.X, e.Y);
            if (itemInfo.Item != null)
            {
                //string fileName = itemInfo.Item.SubItems[0].Text; //文件名
                string fileAbsPath = itemInfo.Item.SubItems[1].Text; //文件完整路径
                //string createTime = itemInfo.Item.SubItems[2].Text; // 文件创建时间
                string fileType = itemInfo.Item.SubItems[3].Text; //文件类型
                DisplaySelectedItem(fileAbsPath, fileType);
            }
        }

        //排序,把时间最靠后的放在最上面
        public void Reorder()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(FileDataPath);  
            if (!dirInfo.Exists)  
                 return;
            string[] filespath = Directory.GetFiles(FileDataPath);
            fileList = new FileInfoList(filespath);
            InitListView(ref fileList);
        }

        private void InitListView(ref FileInfoList fileList)
        {
            ImgVideoListView.Items.Clear();
            this.ImgVideoListView.BeginUpdate();
            foreach (FileInfoWithThumbnail file in fileList.list)
            {
                ListViewItem item = new ListViewItem();
                item.Text = file.fileInfo.Name;
                item.ImageIndex = file.iconIndex;
                //写入文件完成的路径
                item.SubItems.Add(file.fileInfo.FullName); 
                //写入最后写入时间
                item.SubItems.Add(file.fileInfo.LastWriteTime.ToString());
                //写入图片格式
                item.SubItems.Add(file.fileInfo.Extension.Replace(".", ""));
                ImgVideoListView.Items.Add(item);
            }
            ImgVideoListView.LargeImageList = fileList.imageListThumbnail;
            ImgVideoListView.Show();
            this.ImgVideoListView.EndUpdate();
        }

    }


    class FileInfoList
    {
        public List<FileInfoWithThumbnail> list;
        public ImageList imageListThumbnail;

        /// <summary>
        /// 根据文件路径获取生成文件信息，并提取文件的图标
        /// </summary>
        /// <param name="filespath"></param>
        public FileInfoList(string[] filespath)
        {
            list = new List<FileInfoWithThumbnail>();
            imageListThumbnail = new ImageList();
            imageListThumbnail.ImageSize = new Size(128, 72);

            foreach (string path in filespath)
            {
                FileInfoWithThumbnail file = new FileInfoWithThumbnail(path);
                imageListThumbnail.Images.Add(file.thumbnail);
                file.iconIndex = imageListThumbnail.Images.Count - 1;
                list.Add(file);
            }
        }
    }
    class FileInfoWithThumbnail
    {
        public static int thumbnailHeight = 72;
        public static int thumbnailWidth = 128;
        public FileInfo fileInfo;
        public Bitmap thumbnail; //缩略图,大小为16:9的
        public int iconIndex;
        public FileInfoWithThumbnail(string path)
        {
            fileInfo = new FileInfo(path);
            FileTypeEnum curFileType = GetInputFileType(ref path);
       
            if (curFileType == FileTypeEnum.IMAGE)
            {
                Image img = Image.FromFile(path);
                Image myThumbnail = img.GetThumbnailImage(thumbnailWidth, thumbnailHeight, () => { return false; }, IntPtr.Zero);
                thumbnail = new Bitmap(myThumbnail);
                img.Dispose();
                myThumbnail.Dispose();
            }
            else if (curFileType == FileTypeEnum.VIDEO)
            {
                VideoFileReader videoFileReader = new VideoFileReader();
                videoFileReader.Open(path);
                Bitmap videoFrame = videoFileReader.ReadVideoFrame();
                Image myThumbnail = videoFrame.GetThumbnailImage(thumbnailWidth, thumbnailHeight, () => { return false; }, IntPtr.Zero);
                thumbnail = new Bitmap(myThumbnail);
                videoFrame.Dispose();
                myThumbnail.Dispose();
            }

        }

        private FileTypeEnum GetInputFileType(ref string path)
        {
            FileTypeEnum fileType = FileTypeEnum.UNKNOWN_TYPE ;
            string fileStrType = path.Substring(path.LastIndexOf("."));
            if (fileStrType == ".jpg" || fileStrType == ".jpeg")
            {
                fileType = FileTypeEnum.IMAGE;
            }
            else if (fileStrType == ".avi" || fileStrType == ".mp4")
            {
                fileType = FileTypeEnum.VIDEO;
            }
            return fileType;
        }
    }

        
    }
