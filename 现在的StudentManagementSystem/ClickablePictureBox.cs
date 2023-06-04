using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem
{
    public class ClickablePictureBox : PictureBox
    {
        private ImageList imageList;
        private int currentImageIndex = 0;

        public ClickablePictureBox()
        {
            this.Click += ClickablePictureBox_Click;
            this.SizeMode = PictureBoxSizeMode.Zoom;
        }

        [Category("Appearance")]
        [Description("The image list containing the images.")]
        public ImageList ImageList
        {
            get { return imageList; }
            set
            {
                imageList = value;
                if (imageList != null && imageList.Images.Count > 0)
                    this.Image = imageList.Images[currentImageIndex];
            }
        }

        [Category("Behavior")]
        [Description("The index of the currently displayed image.")]
        public int CurrentImageIndex
        {
            get { return currentImageIndex; }
            set
            {
                if (imageList == null || value < 0 || value >= imageList.Images.Count)
                    return;

                currentImageIndex = value;
                this.Image = imageList.Images[currentImageIndex];
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            AdjustImageSize();
        }

        private void AdjustImageSize()
        {
            if (this.Image == null)
                return;

            float ratioWidth = (float)this.Width / this.Image.Width;
            float ratioHeight = (float)this.Height / this.Image.Height;
            float ratio = Math.Min(ratioWidth, ratioHeight);

            int newWidth = (int)(this.Image.Width * ratio);
            int newHeight = (int)(this.Image.Height * ratio);

            this.ClientSize = new Size(newWidth, newHeight);
        }

        private void ClickablePictureBox_Click(object sender, EventArgs e)
        {
            if (imageList != null && imageList.Images.Count > 1)
            {
                currentImageIndex = (currentImageIndex + 1) % imageList.Images.Count;
                this.Image = imageList.Images[currentImageIndex];
                AdjustImageSize();
            }
        }
    }

}
