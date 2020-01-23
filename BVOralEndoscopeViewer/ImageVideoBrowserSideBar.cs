using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;

namespace BVOralEndoscopeViewer
{
    public partial class ImageVideoBrowserSideBar : UserControl
    {
        //当前本控件显示的视频和图像的路径
        public string FileDataPath { set; get; }
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
            //判断当前待显示文件的路径是否合法
           DirectoryInfo dirInfo = new DirectoryInfo(FileDataPath);  
            if (!dirInfo.Exists)  
                return;
            //清空条目
            this.ImgVideoListView.Items.Clear();
            DirectoryInfo[] infos = dirInfo.GetDirectories();  
            int iDirIconIndex=FileIcon.GetIconIndex("");  
            ImgVideoListView.BeginUpdate();
            foreach (DirectoryInfo d in infos)
            {
                ListViewItem lv = new ListViewItem(d.Name);
                lv.ImageIndex = iDirIconIndex;
                ImgVideoListView.Items.Add(lv);
            }//先获取所有文件的信息

            string[] files = Directory.GetFiles(FileDataPath);
            foreach (string str in files)
            {
                ListViewItem lv = new ListViewItem(Path.GetFileName(str));
                FileInfo fi = new FileInfo(str);
                string num = fi.Length.ToString();
                for (int i = num.Length - 3; i > 0; i -= 3)
                {
                    num = num.Insert(i, ",");
                }
                lv.SubItems.Add(num);
                lv.ImageIndex = FileIcon.GetIconIndex(str);
                ImgVideoListView.Items.Add(lv);
            }
            ImgVideoListView.EndUpdate();  
        }
    }






    class FileIcon
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct SHFILEINFO
        {
            public IntPtr hIcon;
            public int iIcon;
            public uint dwAttributes;
            public string szDisplayName;
            public string szTypeName;
        };
        const uint SHGFI_ICON = 0x00000100;
        const uint SHGFI_LARGEICON = 0x00000000;
        const uint SHGFI_SMALLICON = 0x00000001;
        const uint SHGFI_SYSICONINDEX = 0x4000;

        [DllImport("shell32.dll")]
        public static extern IntPtr SHGetFileInfo(string filename, uint fileattributes, ref SHFILEINFO shfi, uint cbfi, uint flag);

        [DllImport("user32.dll")]
        public static extern bool DestroyIcon(IntPtr hIcon);

        public static uint LVM_FIRST = 0x1000;
        public static uint LVM_SETIMAGELIST = LVM_FIRST + 3;
        public static uint LVSIL_NORMAL = 0;
        public static uint LVSIL_SMALL = 1;

        [DllImport("User32.DLL")]
        public static extern int SendMessage(IntPtr hWnd, uint Msg, uint wParam, IntPtr lParam);

        public static void ListViewSetImageList(System.Windows.Forms.ListView lv)
        {
            SHFILEINFO shfi = new SHFILEINFO();
            IntPtr hImageList;
            hImageList = SHGetFileInfo("", 0, ref shfi, (uint)Marshal.SizeOf(shfi), SHGFI_LARGEICON | SHGFI_SYSICONINDEX);
            SendMessage(lv.Handle, LVM_SETIMAGELIST, LVSIL_NORMAL, hImageList);
            hImageList = SHGetFileInfo("", 0, ref shfi, (uint)Marshal.SizeOf(shfi), SHGFI_SMALLICON | SHGFI_SYSICONINDEX);
            SendMessage(lv.Handle, LVM_SETIMAGELIST, LVSIL_SMALL, hImageList);
        }
        public static int GetIconIndex(string filename)
        {
            SHFILEINFO shfi = new SHFILEINFO();
            SHGetFileInfo(filename, 0, ref shfi, (uint)Marshal.SizeOf(shfi), SHGFI_ICON | SHGFI_SMALLICON);
            return (int)shfi.iIcon;
        }
        public static Icon GetSmallIconFromFile(string filename)
        {
            SHFILEINFO shfi = new SHFILEINFO();
            SHGetFileInfo(filename, 0, ref shfi, (uint)Marshal.SizeOf(shfi), SHGFI_ICON | SHGFI_SMALLICON);
            Icon myicon = (Icon)Icon.FromHandle(shfi.hIcon).Clone();
            DestroyIcon(shfi.hIcon);
            return myicon;
        }
        public static Icon GetLargeIconFromFile(string filename)
        {
            SHFILEINFO shfi = new SHFILEINFO();
            SHGetFileInfo(filename, 0, ref shfi, (uint)Marshal.SizeOf(shfi), SHGFI_ICON | SHGFI_LARGEICON);
            Icon myicon = (Icon)Icon.FromHandle(shfi.hIcon).Clone();
            DestroyIcon(shfi.hIcon);
            return myicon;
        }
    }













}
