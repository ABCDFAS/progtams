using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem
{
    public class PictureButton : PictureBox
    {
        public PictureButton()
        {
            this.SizeMode = PictureBoxSizeMode.Zoom;  //或者使用PictureBoxSizeMode.StretchImage
            this.BackColor = Color.Transparent;
            this.Cursor = Cursors.Hand; //更改光标以指示这是一个可以点击的元素
        }

        //处理鼠标点击事件，添加你的逻辑
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            
        }
    }
}
