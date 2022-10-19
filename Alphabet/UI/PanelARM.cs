using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Alphabet.Service;

namespace Alphabet.UI
{
    class StoragePanelsARMs
    {
        private List<PanelARM> _panelsARMs;

        public StoragePanelsARMs()
        {
            _panelsARMs = new List<PanelARM>();
        }

        public void AddItem(PanelARM panelARM)
        {
            panelARM.CreateARM();
            _panelsARMs.Add(panelARM);
        }

        public void SetParent(Control parent)
        {
            Control[] panelsARMs = new Control[_panelsARMs.Count];
            for (int i = 0; i < _panelsARMs.Count; i++)
                panelsARMs[i] = _panelsARMs[i].GetPanelARM();

            parent.Controls.AddRange(panelsARMs);
        }
    }

    internal class PanelARM
    {
        private TableLayoutPanel _ground;

        public ARM Arm { get; set; }

        public string ARMName { get; set; }

        public Image Icon { get; set; }

        public void CreateARM()
        {
            CreateGroundARM();
            CreateViewIconARM();
            CreateViewNameARM();
        }

        public TableLayoutPanel GetPanelARM()
        {
            return _ground;
        }

        private void CreateGroundARM()
        {
            _ground = new TableLayoutPanel();
            _ground.Dock = DockStyle.Top;
            _ground.Size = new Size(195, 37);
            _ground.Margin = new Padding(3, 3, 3, 3);
            _ground.RowCount = 1;
            _ground.ColumnCount = 2;
            _ground.Cursor = Cursors.Hand;
            _ground.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 23.59f));
            _ground.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 76.41f));
            _ground.CellBorderStyle = TableLayoutPanelCellBorderStyle.OutsetPartial;
            _ground.Click += LoadingArmClick;
            _ground.MouseEnter += ControlMouseEnter;
            _ground.MouseLeave += ControlMouseLeave;
        }

        private void CreateViewIconARM()
        {
            PictureBox pb = new PictureBox();
            pb.Size = new Size(40, 28);
            pb.Dock = DockStyle.Fill;
            pb.Image = Icon;
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            pb.Click += LoadingArmClick;
            pb.MouseEnter += ControlMouseEnter;
            pb.MouseLeave += ControlMouseLeave;
            AddControlOnGround(pb, 0, 0);
        }

        private void CreateViewNameARM()
        {
            Label viewNameARM = new Label();
            viewNameARM.Size = new Size(49, 10);
            viewNameARM.TextAlign = ContentAlignment.TopCenter;
            viewNameARM.AutoSize = true;
            viewNameARM.Text = ARMName;
            viewNameARM.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            viewNameARM.Click += LoadingArmClick;
            viewNameARM.MouseEnter += ControlMouseEnter;
            viewNameARM.MouseLeave += ControlMouseLeave;
            AddControlOnGround(viewNameARM, 1, 0);
        }

        private void AddControlOnGround(Control child, int row, int column)
        {
            _ground.Controls.Add(child, row, column);
        }

        private void LoadingArmClick(object sender, EventArgs e)
        {
            Logger.Writer(new SQLWriteSystemLogger(
                new AttributeSystemLog()
                {
                    DateTimeCreate = DateTime.Now,
                    LevelMessage = "Info",
                    Message = "Выбран АРМ " + ARMName + "."
                }));

            Arm.ARMForm.ShowDialog();
        }

        private void ControlMouseEnter(object sender, EventArgs e)
        {
            _ground.BackColor = SystemColors.GradientInactiveCaption;
        }

        private void ControlMouseLeave(object sender, EventArgs e)
        {
            _ground.BackColor = Color.Transparent;
        }
    }
}
