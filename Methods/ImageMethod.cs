using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace PKLib_Method.Methods
{
    class ImageMethod
    {
        /// <summary>
        /// 重設圖片大小
        /// </summary>
        /// <param name="inputImg">來源圖片</param>
        /// <param name="setWidth">設定寬</param>
        /// <param name="setHeight">設定高</param>
        /// <returns></returns>
        public Byte[] reSizeImage(Stream inputImg, int setWidth, int setHeight)
        {
            //宣告
            int getWidth = 0;
            int getHeight = 0;

            //取得來源圖檔
            using (Image GetImg = new Bitmap(inputImg))
            {
                //取得原始圖檔寬高
                getWidth = GetImg.Width;
                getHeight = GetImg.Height;

                //等比例計算&設定寬高
                if (!(getWidth < setWidth & getHeight < setHeight))
                {
                    if (getWidth > getHeight)
                    {
                        setHeight = setWidth * getHeight / getWidth;
                    }
                    else
                    {
                        setWidth = setHeight * getWidth / getHeight;
                    }
                }
                else
                {
                    //寬高皆小於指定數值時, 則使用原數值
                    setWidth = getWidth;
                    setHeight = getHeight;
                }


                //設定新的圖片定義
                using (Bitmap NewImg = new Bitmap(setWidth, setHeight))
                {
                    //載入繪圖介面
                    using (Graphics graphic = Graphics.FromImage(NewImg))
                    {
                        //設定圖片品質
                        graphic.CompositingQuality = CompositingQuality.HighQuality;
                        graphic.SmoothingMode = SmoothingMode.HighQuality;
                        graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        
                        //於座標(0,0)開始繪製來源影像
                        graphic.DrawImage(GetImg, 0, 0, setWidth, setHeight);
                        
                        //將圖片轉為byte
                        ImageConverter converter = new ImageConverter();

                        return (byte[])converter.ConvertTo(NewImg, typeof(byte[]));
                                                
                    }
                }

            }

        }


        /// <summary>
        /// 旋轉圖片
        /// </summary>
        /// <param name="inputImg">來源圖片</param>
        /// <param name="setDegree">角度</param>
        /// <returns></returns>
        public Byte[] rotateImage(Stream inputImg, float setDegree)
        {
            //取得來源圖檔
            using (Image GetImg = new Bitmap(inputImg))
            {
                //設定新的圖片定義
                using (Bitmap NewImg = new Bitmap(GetImg.Width, GetImg.Height))
                {
                    //載入繪圖介面
                    using (Graphics graphic = Graphics.FromImage(NewImg))
                    {
                        //設定圖片品質
                        graphic.CompositingQuality = CompositingQuality.HighQuality;
                        graphic.SmoothingMode = SmoothingMode.HighQuality;
                        graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;

                        //設定中心點
                        graphic.TranslateTransform((float)GetImg.Width / 2, (float)GetImg.Height / 2);

                        //旋轉角度
                        graphic.RotateTransform(setDegree);

                        //還原中心點
                        graphic.TranslateTransform(-(float)GetImg.Width / 2, -(float)GetImg.Height / 2);


                        //於座標(0,0)開始繪製來源影像
                        graphic.DrawImage(GetImg, 0, 0, GetImg.Width, GetImg.Height);


                        //將圖片轉為byte
                        ImageConverter converter = new ImageConverter();
                        return (byte[])converter.ConvertTo(NewImg, typeof(byte[]));

                    }
                }


            }

        }
    }
}
