using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace PictureManager
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        List<FileInfo> fileInfos = new List<FileInfo>();
        int index;
        int wrongCount;


        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // 커스텀 타이틀바 이용
            // Drag & Move
            this.DragMove();
        }

        private void exitButton_MouseLeftDown(object sender, MouseButtonEventArgs e)
        {
            // 커스텀 종료 버튼
            this.Close();
        }

        private void sortButton_Click(object sender, RoutedEventArgs e)
        {
            // 사진 정렬하기 버튼
            using (FolderBrowserDialog folder = new FolderBrowserDialog())
            {
                if (folder.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    progressBar.Value = 0;
                    string path = folder.SelectedPath;
                    wrongCount = 0;

                    for (int i = 0; i < fileInfos.Count; i++)
                    {
                        getMetaData(fileInfos[i], path);
                    }

                    listBox.Items.Add(fileInfos.Count - wrongCount + "개 정렬 완료");
                    listBox.Items.Add(wrongCount + "개 누락됨");

                }
            }
        }

        private void loadButton_Click(object sender, RoutedEventArgs e)
        {
            // 폴더 불러오기 버튼
            using (FolderBrowserDialog folder = new FolderBrowserDialog())
            {
                if (folder.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string path = folder.SelectedPath;
                    fileInfos.Clear();
                    loadToList(path);
                }
            }
        }

        private void loadToList(string path)
        {
            // 이미지 파일 정보를 리스트에 로드
            // 사진 확장자만 담아내기
            DirectoryInfo directory = new DirectoryInfo(path);

            foreach (var i in directory.GetFiles())
            {
                if (i.Extension.ToLower() == ".jpg" || i.Extension.ToLower() == ".png")
                {
                    fileInfos.Add(i);

                }

            }

            listBox.Items.Clear();
            progressBar.Maximum = fileInfos.Count;
            listBox.Items.Add(fileInfos.Count + "개 사진 발견됨");
            index = 0;
            loadImage();
        }

        private void loadImage()
        {
            // 이미지 시각화 기능
            // leftButton, rightButton 클릭 시 리스트에 담긴 사진들을 하나씩 넘겨줌
            try
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(fileInfos[index].FullName);
                bitmap.EndInit();
                image.Source = bitmap;
            }

            //사진 불러오기 전 leftButton, rightButton 오작동 방지
            catch (ArgumentOutOfRangeException)
            {
                index = 0;
            }


        }

        private void leftButton_Click(object sender, RoutedEventArgs e)
        {
            // 사진 넘기기
            // 사진 인덱스가 처음으로 도달하면
            // 목록 맨 끝의 사진으로 인덱스 보내기

            if (index <= 0)
            {
                index = fileInfos.Count;
            }
            index--;
            loadImage();
        }

        private void rightButton_Click(object sender, RoutedEventArgs e)
        {
            // 사진 넘기기
            // 사진 인덱스가 끝에 도달하면
            // 목록 맨 처음 사진으로 인덱스 보내기

            if (index >= fileInfos.Count - 1)
            {
                index = 0;
                loadImage();
            }

            else
            {
                index++;
                loadImage();
            }
        }

        private void getMetaData(FileInfo i, string path)
        {
            using (FileStream fs = new FileStream(i.FullName, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                try
                {
                    BitmapSource img = BitmapFrame.Create(fs);
                    BitmapMetadata md = (BitmapMetadata)img.Metadata;
                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.Append(path);
                    stringBuilder.Append("/");
                    stringBuilder.Append(md.DateTaken.Substring(0, 7));

                    // 날짜별로 분류할 폴더 만들기
                    if (!Directory.Exists(stringBuilder.ToString()))
                    {
                        Directory.CreateDirectory(stringBuilder.ToString());
                    }

                    i.CopyTo(stringBuilder.ToString() + "\\" + i.Name);
                }


                catch (NullReferenceException)
                {
                    // 날짜 정보가 존재하지 않을 시에는
                    // 누락 횟수 더하기
                    wrongCount++;
                }

                finally
                {
                    // progressBar 업데이트
                    this.Dispatcher.Invoke(
                      (ThreadStart)(() => { progressBar.Value += 1; }), System.Windows.Threading.DispatcherPriority.Render);
                }
            }
        }
    }
}
