using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.Drawing.Imaging;

namespace BVOralEndoscopeViewer
{
    public partial class ImageVideoBrowserSideBar : UserControl
    {
        //当前本控件显示的视频和图像的路径
        public string FileDataPath { set; get; }
        //存放需要排列的文件的列表信息
        private FileInfoList fileList;
        public ImageVideoBrowserSideBar()
        {
            InitializeComponent();
        }

        //
        private void ImgVideoListView_DoubleClick(object sender, EventArgs e)
        {

        }

        //排序,把时间最靠后的放在最上面
        public void Reorder()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(FileDataPath);  
            if (!dirInfo.Exists)  
                 return;
            string[] filespath = Directory.GetFiles(FileDataPath);
            fileList = new FileInfoList(filespath);
            InitListView();


            // //判断当前待显示文件的路径是否合法
            //DirectoryInfo dirInfo = new DirectoryInfo(FileDataPath);  
            // if (!dirInfo.Exists)  
            //     return;
            // //清空条目
            // this.ImgVideoListView.Items.Clear();
            // //DirectoryInfo[] infos = dirInfo.GetDirectories();  
            // //int iDirIconIndex=FileIcon.GetIconIndex("");  
            // //ImgVideoListView.BeginUpdate();
            // //foreach (DirectoryInfo d in infos)
            // //{
            // //    ListViewItem lv = new ListViewItem(d.Name);
            // //    lv.ImageIndex = iDirIconIndex;
            // //    ImgVideoListView.Items.Add(lv);
            // //}//先获取所有文件的信息

            // string[] files = Directory.GetFiles(FileDataPath);
            // foreach (string str in files)
            // {
            //     ListViewItem lv = new ListViewItem(Path.GetFileName(str));
            //     FileInfo fi = new FileInfo(str);
            //     string num = fi.Length.ToString();
            //     for (int i = num.Length - 3; i > 0; i -= 3)
            //     {
            //         num = num.Insert(i, ",");
            //     }
            //     lv.SubItems.Add(num);
            //     lv.ImageIndex = FileIcon.GetIconIndex(str);
            //     ImgVideoListView.Items.Add(lv);
            // }
            // ImgVideoListView.EndUpdate();  
        }

        private void InitListView()
        {
            ImgVideoListView.Items.Clear();
            this.ImgVideoListView.BeginUpdate();
            foreach (FileInfoWithThumbnail file in fileList.list)
            {
                ListViewItem item = new ListViewItem();
                item.Text = file.fileInfo.Name.Split('.')[0];
                item.ImageIndex = file.iconIndex;
                item.SubItems.Add(file.fileInfo.LastWriteTime.ToString());
                item.SubItems.Add(file.fileInfo.Extension.Replace(".", ""));
                item.SubItems.Add(string.Format(("{0:N0}"), file.fileInfo.Length));
                ImgVideoListView.Items.Add(item);
            }
            ImgVideoListView.LargeImageList = fileList.imageListThumbnail;
            //ImgVideoListView.SmallImageList = fileList.imageListSmallIcon;
            ImgVideoListView.Show();
            this.ImgVideoListView.EndUpdate();
        }

    }






    //class FileIcon
    //{
    //    [StructLayout(LayoutKind.Sequential)]
    //    public struct SHFILEINFO
    //    {
    //        public IntPtr hIcon;
    //        public int iIcon;
    //        public uint dwAttributes;
    //        public string szDisplayName;
    //        public string szTypeName;
    //    };
    //    const uint SHGFI_ICON = 0x00000100;
    //    const uint SHGFI_LARGEICON = 0x00000000;
    //    const uint SHGFI_SMALLICON = 0x00000001;
    //    const uint SHGFI_SYSICONINDEX = 0x4000;

    //    [DllImport("shell32.dll")]
    //    public static extern IntPtr SHGetFileInfo(string filename, uint fileattributes, ref SHFILEINFO shfi, uint cbfi, uint flag);

    //    [DllImport("user32.dll")]
    //    public static extern bool DestroyIcon(IntPtr hIcon);

    //    public static uint LVM_FIRST = 0x1000;
    //    public static uint LVM_SETIMAGELIST = LVM_FIRST + 3;
    //    public static uint LVSIL_NORMAL = 0;
    //    public static uint LVSIL_SMALL = 1;

    //    [DllImport("User32.DLL")]
    //    public static extern int SendMessage(IntPtr hWnd, uint Msg, uint wParam, IntPtr lParam);

    //    public static void ListViewSetImageList(System.Windows.Forms.ListView lv)
    //    {
    //        SHFILEINFO shfi = new SHFILEINFO();
    //        IntPtr hImageList;
    //        hImageList = SHGetFileInfo("", 0, ref shfi, (uint)Marshal.SizeOf(shfi), SHGFI_LARGEICON | SHGFI_SYSICONINDEX);
    //        SendMessage(lv.Handle, LVM_SETIMAGELIST, LVSIL_NORMAL, hImageList);
    //        hImageList = SHGetFileInfo("", 0, ref shfi, (uint)Marshal.SizeOf(shfi), SHGFI_SMALLICON | SHGFI_SYSICONINDEX);
    //        SendMessage(lv.Handle, LVM_SETIMAGELIST, LVSIL_SMALL, hImageList);
    //    }
    //    public static int GetIconIndex(string filename)
    //    {
    //        SHFILEINFO shfi = new SHFILEINFO();
    //        SHGetFileInfo(filename, 0, ref shfi, (uint)Marshal.SizeOf(shfi), SHGFI_ICON | SHGFI_SMALLICON);
    //        return (int)shfi.iIcon;
    //    }
    //    public static Icon GetSmallIconFromFile(string filename)
    //    {
    //        SHFILEINFO shfi = new SHFILEINFO();
    //        SHGetFileInfo(filename, 0, ref shfi, (uint)Marshal.SizeOf(shfi), SHGFI_ICON | SHGFI_SMALLICON);
    //        Icon myicon = (Icon)Icon.FromHandle(shfi.hIcon).Clone();
    //        DestroyIcon(shfi.hIcon);
    //        return myicon;
    //    }
    //    public static Icon GetLargeIconFromFile(string filename)
    //    {
    //        SHFILEINFO shfi = new SHFILEINFO();
    //        SHGetFileInfo(filename, 0, ref shfi, (uint)Marshal.SizeOf(shfi), SHGFI_ICON | SHGFI_LARGEICON);
    //        Icon myicon = (Icon)Icon.FromHandle(shfi.hIcon).Clone();
    //        DestroyIcon(shfi.hIcon);
    //        return myicon;
    //    }
    //}







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
        public Bitmap thumbnail; //缩略图,大小为16:9的, size为64 * 36
        public int iconIndex;
        public FileInfoWithThumbnail(string path)
        {
            Image img = Image.FromFile(path);
            fileInfo = new FileInfo(path);
            Image myThumbnail = img.GetThumbnailImage(thumbnailWidth, thumbnailHeight,() => { return false; }, IntPtr.Zero);
            thumbnail = new Bitmap(myThumbnail);
        }
    }



    public class ImageClass
    {
        public Image ResourceImage;
        private int ImageWidth;
        private int ImageHeight;

        public string ErrMessage;

        public ImageClass(string ImageFileName)
        {
            ResourceImage = Image.FromFile(ImageFileName);
            ErrMessage = "";
        }

        public bool ThumbnailCallback()
        {
            return false;
        }

        /// <summary>   
        /// 生成缩略图重载方法1，返回缩略图的Image对象 
        /// </summary>   
        /// <param name="Width">缩略图的宽度</param>   
        /// <param name="Height">缩略图的高度</param>   
        /// <returns>缩略图的Image对象</returns>   
        public Image GetReducedImage(int Width, int Height)
        {
            try
            {
                Image ReducedImage;

                Image.GetThumbnailImageAbort callb = new Image.GetThumbnailImageAbort(ThumbnailCallback);

                ReducedImage = ResourceImage.GetThumbnailImage(Width, Height, callb, IntPtr.Zero);

                return ReducedImage;
            }
            catch (Exception e)
            {
                ErrMessage = e.Message;
                return null;
            }
        }

        /// <summary>   
        /// 生成缩略图重载方法2，将缩略图文件保存到指定的路径 
        /// </summary>   
        /// <param name="Width">缩略图的宽度  
        /// <param name="Height">缩略图的高度
        /// <param name="targetFilePath">缩略图保存的全文件名，(带路径)，参数格式：D:Images ilename.jpg</param>   
        /// <returns>成功返回true，否则返回false</returns>   
        public bool GetReducedImage(int Width, int Height, string targetFilePath)
        {
            try
            {
                Image ReducedImage;

                Image.GetThumbnailImageAbort callb = new Image.GetThumbnailImageAbort(ThumbnailCallback);

                ReducedImage = ResourceImage.GetThumbnailImage(Width, Height, callb, IntPtr.Zero);
                ReducedImage.Save(@targetFilePath, ImageFormat.Jpeg);

                ReducedImage.Dispose();

                return true;
            }
            catch (Exception e)
            {
                ErrMessage = e.Message;
                return false;
            }
        }

        /// <summary>   
        /// 生成缩略图重载方法3，返回缩略图的Image对象 
        /// </summary>   
        /// <param name="Percent">缩略图的宽度百分比 如：需要百分之80，就填0.8</param>     
        /// <returns>缩略图的Image对象</returns>   
        public Image GetReducedImage(double Percent)
        {
            try
            {
                Image ReducedImage;

                Image.GetThumbnailImageAbort callb = new Image.GetThumbnailImageAbort(ThumbnailCallback);

                ImageWidth = Convert.ToInt32(ResourceImage.Width * Percent);
                ImageHeight = Convert.ToInt32(ResourceImage.Width * Percent);

                ReducedImage = ResourceImage.GetThumbnailImage(ImageWidth, ImageHeight, callb, IntPtr.Zero);

                return ReducedImage;
            }
            catch (Exception e)
            {
                ErrMessage = e.Message;
                return null;
            }
        }

        /// <summary>   
        /// 生成缩略图重载方法4，返回缩略图的Image对象  
        /// </summary>   
        /// <param name="Percent">缩略图的宽度百分比 如：需要百分之80，就填0.8</param>     
        /// <param name="targetFilePath">缩略图保存的全文件名，(带路径)，参数格式：D:Images ilename.jpg</param>   
        /// <returns>成功返回true,否则返回false</returns> 
        public bool GetReducedImage(double Percent, string targetFilePath)
        {
            try
            {
                Image ReducedImage;

                Image.GetThumbnailImageAbort callb = new Image.GetThumbnailImageAbort(ThumbnailCallback);

                ImageWidth = Convert.ToInt32(ResourceImage.Width * Percent);
                ImageHeight = Convert.ToInt32(ResourceImage.Width * Percent);

                ReducedImage = ResourceImage.GetThumbnailImage(ImageWidth, ImageHeight, callb, IntPtr.Zero);

                ReducedImage.Save(@targetFilePath, ImageFormat.Jpeg);

                ReducedImage.Dispose();

                return true;
            }
            catch (Exception e)
            {
                ErrMessage = e.Message;
                return false;
            }
        }

    }











}
