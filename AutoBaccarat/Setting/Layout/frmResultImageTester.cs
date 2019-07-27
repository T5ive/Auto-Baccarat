using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Reflection;
using System.Windows.Forms;

namespace AutoBaccarat
{
    [Obfuscation(Feature = "Apply to member * when method or constructor: virtualization", Exclude = false)]
    [Obfuscation(Feature = "PEVerify", Exclude = false)]
    [Obfuscation(Feature = "debug [secure] with password 12345A", Exclude = false)]
    [Obfuscation(Feature = "encrypt resources", Exclude = false)]
    public partial class frmResultImageTester : Form
    {
        public frmResultImageTester()
        {
            InitializeComponent();
        }

        private Bitmap _picture;

        private int _xCount;

        private int _yCount;

        public void GetPicture(Bitmap picture, int xCount, int yCount)
        {
            _picture = picture;
            _xCount = xCount;
            _yCount = yCount;
            GetScore();
        }

        private unsafe void GetScore()
        {
            var frmMain = new FrmMain();
            void* ptr = stackalloc byte[44];
            try
            {
                if (_xCount > 0 & _yCount > 0 && _picture != null && _picture.Width >= 10 && _picture.Height >= 10)
                {
                    frmMain.PosX2 = _xCount;
                    frmMain.PosY2 = _yCount;
                    *(int*)((byte*)ptr + 8) = 0;
                    *(int*)((byte*)ptr + 4) = 0;
                    var list = GridBuild(frmMain, _picture, ref *(int*)((byte*)ptr + 8), ref *(int*)((byte*)ptr + 4));
                    *(int*)((byte*)ptr + 8) = checked(*(int*)((byte*)ptr + 8) + 6);
                    *(int*)((byte*)ptr + 4) = checked(*(int*)((byte*)ptr + 4) + 6);
                    var list2 = new List<string>();
                    dgvCurrentResultImg.Columns.Clear();
                    ref var ptr2 = ref *(int*)((byte*)ptr + 12);
                    var num = 0;
                    *(int*)((byte*)ptr + 28) = checked(_xCount - 1);
                    ptr2 = num;
                    while (*(int*)((byte*)ptr + 12) <= *(int*)((byte*)ptr + 28))
                    {
                        var dataGridViewImageColumn = new DataGridViewImageColumn();
                        dataGridViewImageColumn.Width = *(int*)((byte*)ptr + 8);
                        dataGridViewImageColumn.ImageLayout = DataGridViewImageCellLayout.Normal;
                        dgvCurrentResultImg.Columns.Add(dataGridViewImageColumn);
                        *(int*)((byte*)ptr + 12) = checked(*(int*)((byte*)ptr + 12) + 1);
                    }
                    ref var ptr3 = ref *(int*)((byte*)ptr + 16);
                    var num2 = 0;
                    *(int*)((byte*)ptr + 32) = checked(_yCount - 1);
                    ptr3 = num2;
                    while (*(int*)((byte*)ptr + 16) <= *(int*)((byte*)ptr + 32))
                    {
                        dgvCurrentResultImg.Rows.Add(list2.ToArray());
                        dgvCurrentResultImg.Rows[checked(dgvCurrentResultImg.Rows.Count - 1)].Height = *(int*)((byte*)ptr + 4);
                        *(int*)((byte*)ptr + 16) = checked(*(int*)((byte*)ptr + 16) + 1);
                    }
                    dgvCurrentResultImg.ClearSelection();
                    *(int*)ptr = 0;
                    ref var ptr4 = ref *(int*)((byte*)ptr + 20);
                    var num3 = 0;
                    *(int*)((byte*)ptr + 36) = checked(_xCount - 1);
                    ptr4 = num3;
                    while (*(int*)((byte*)ptr + 20) <= *(int*)((byte*)ptr + 36))
                    {
                        ref var ptr5 = ref *(int*)((byte*)ptr + 24);
                        var num4 = 0;
                        *(int*)((byte*)ptr + 40) = checked(_yCount - 1);
                        ptr5 = num4;
                        while (*(int*)((byte*)ptr + 24) <= *(int*)((byte*)ptr + 40))
                        {
                            var value = new Bitmap(*(int*)((byte*)ptr + 8), *(int*)((byte*)ptr + 4));
                            if (*(int*)ptr < list.Count)
                            {
                                value = list[*(int*)ptr];
                                dgvCurrentResultImg.Rows[*(int*)((byte*)ptr + 24)].Cells[*(int*)((byte*)ptr + 20)].Value = value;
                                dgvCurrentResultImg.Rows[*(int*)((byte*)ptr + 24)].Cells[*(int*)((byte*)ptr + 20)].Style.BackColor = Color.DarkGray;
                            }
                            *(int*)ptr = checked(*(int*)ptr + 1);
                            *(int*)((byte*)ptr + 24) = checked(*(int*)((byte*)ptr + 24) + 1);
                        }
                        *(int*)((byte*)ptr + 20) = checked(*(int*)((byte*)ptr + 20) + 1);
                    }
                }
            }
            catch
            {
            }
        }

        internal static unsafe List<Bitmap> GridBuild(FrmMain frmMain, Bitmap picture, ref int posX, ref int posY)
        {
            void* ptr = stackalloc byte[48];
            var list = new List<Bitmap>();
            *(int*)((byte*)ptr + 4) = 0;
            *(int*)ptr = 0;
            if (frmMain != null && picture.Width > 10 && picture.Height > 10)
            {
                if (frmMain.PosX2 > 0 & frmMain.PosY2 > 0)
                {
                    var d = new decimal(picture.Width / (double)frmMain.PosX2);
                    var d2 = new decimal(picture.Height / (double)frmMain.PosY2);
                    ref var ptr2 = ref *(int*)((byte*)ptr + 16);
                    var num = 0;
                    *(int*)((byte*)ptr + 40) = checked(frmMain.PosX2 - 1);
                    ptr2 = num;
                    while (*(int*)((byte*)ptr + 16) <= *(int*)((byte*)ptr + 40))
                    {
                        *(int*)((byte*)ptr + 8) = (int)Math.Round((Convert.ToDouble(decimal.Multiply(d, new decimal(*(int*)((byte*)ptr + 16)))) + 0.5));
                        *(int*)((byte*)ptr + 12) = 0;
                        if (*(int*)((byte*)ptr + 16) < checked(frmMain.PosX2 - 1))
                        {
                            *(int*)((byte*)ptr + 20) = (int)Math.Round((Convert.ToDouble(decimal.Multiply(d, new decimal(checked(*(int*)((byte*)ptr + 16) + 1)))) + 0.5));
                            *(int*)((byte*)ptr + 12) = checked(*(int*)((byte*)ptr + 20) - *(int*)((byte*)ptr + 8));
                        }
                        else
                        {
                            *(int*)((byte*)ptr + 12) = checked(picture.Width - *(int*)((byte*)ptr + 8));
                        }
                        ref var ptr3 = ref *(int*)((byte*)ptr + 32);
                        var num2 = 0;
                        *(int*)((byte*)ptr + 44) = checked(frmMain.PosY2 - 1);
                        ptr3 = num2;
                        while (*(int*)((byte*)ptr + 32) <= *(int*)((byte*)ptr + 44))
                        {
                            *(int*)((byte*)ptr + 28) = (int)Math.Round((Convert.ToDouble(decimal.Multiply(d2, new decimal(*(int*)((byte*)ptr + 32)))) + 0.5));
                            *(int*)((byte*)ptr + 24) = 0;
                            if (*(int*)((byte*)ptr + 32) < checked(frmMain.PosY2 - 1))
                            {
                                *(int*)((byte*)ptr + 36) = (int)Math.Round((Convert.ToDouble(decimal.Multiply(d2, new decimal(checked(*(int*)((byte*)ptr + 32) + 1)))) + 0.5));
                                *(int*)((byte*)ptr + 24) = checked(*(int*)((byte*)ptr + 36) - *(int*)((byte*)ptr + 28));
                            }
                            else
                            {
                                *(int*)((byte*)ptr + 24) = checked(picture.Height - *(int*)((byte*)ptr + 28));
                            }
                            if (*(int*)((byte*)ptr + 24) > 5 & *(int*)((byte*)ptr + 12) > 5)
                            {
                                var rect = new Rectangle(*(int*)((byte*)ptr + 8), *(int*)((byte*)ptr + 28), *(int*)((byte*)ptr + 12), *(int*)((byte*)ptr + 24));
                                var item = picture.Clone(rect, PixelFormat.Format32bppArgb);
                                list.Add(item);
                                if (*(int*)((byte*)ptr + 12) > *(int*)((byte*)ptr + 4))
                                {
                                    *(int*)((byte*)ptr + 4) = *(int*)((byte*)ptr + 12);
                                }
                                if (*(int*)((byte*)ptr + 24) > *(int*)ptr)
                                {
                                    *(int*)ptr = *(int*)((byte*)ptr + 24);
                                }
                            }
                            *(int*)((byte*)ptr + 32) = checked(*(int*)((byte*)ptr + 32) + 1);
                        }
                        *(int*)((byte*)ptr + 16) = checked(*(int*)((byte*)ptr + 16) + 1);
                    }
                }
            }
            posX = *(int*)((byte*)ptr + 4);
            posY = *(int*)ptr;
            return list;
        }
    }
}