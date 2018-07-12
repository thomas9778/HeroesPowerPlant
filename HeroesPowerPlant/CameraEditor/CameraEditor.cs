﻿using System;
using System.Linq;
using System.Windows.Forms;
using static HeroesPowerPlant.MemoryFunctions;
using static HeroesPowerPlant.CameraEditor.CameraEditorFunctions;
using SharpDX;

namespace HeroesPowerPlant.CameraEditor
{
    public partial class CameraEditor : Form
    {
        public CameraEditor()
        {
            InitializeComponent();
            numericUpDown1.Maximum = Decimal.MaxValue;
            numericUpDown2.Maximum = Decimal.MaxValue;
            numericUpDown3.Maximum = Decimal.MaxValue;
            numericUpDown4.Maximum = Decimal.MaxValue;
            numericUpDown5.Maximum = Decimal.MaxValue;
            numericUpDownColPosX.Maximum = Decimal.MaxValue;
            numericUpDownColPosY.Maximum = Decimal.MaxValue;
            numericUpDownColPosZ.Maximum = Decimal.MaxValue;
            numericUpDownColRotX.Maximum = Decimal.MaxValue;
            numericUpDownColRotY.Maximum = Decimal.MaxValue;
            numericUpDownColRotZ.Maximum = Decimal.MaxValue;
            numericUpDownColSclX.Maximum = Decimal.MaxValue;
            numericUpDownColSclY.Maximum = Decimal.MaxValue;
            numericUpDownColSclZ.Maximum = Decimal.MaxValue;
            numericUpDownCamPosX.Maximum = Decimal.MaxValue;
            numericUpDownCamPosY.Maximum = Decimal.MaxValue;
            numericUpDownCamPosZ.Maximum = Decimal.MaxValue;
            numericUpDownCamRotX.Maximum = Decimal.MaxValue;
            numericUpDownCamRotY.Maximum = Decimal.MaxValue;
            numericUpDownCamRotZ.Maximum = Decimal.MaxValue;
            numericUpDown21.Maximum = Decimal.MaxValue;
            numericUpDown22.Maximum = Decimal.MaxValue;
            numericUpDown23.Maximum = Decimal.MaxValue;
            numericUpDown24.Maximum = Decimal.MaxValue;
            numericUpDown25.Maximum = Decimal.MaxValue;
            numericUpDown26.Maximum = Decimal.MaxValue;
            numericUpDown27.Maximum = Decimal.MaxValue;
            numericUpDown28.Maximum = Decimal.MaxValue;
            numericUpDown29.Maximum = Decimal.MaxValue;
            numericUpDown30.Maximum = Decimal.MaxValue;
            numericUpDown31.Maximum = Decimal.MaxValue;
            numericUpDown32.Maximum = Decimal.MaxValue;
            numericUpDown33.Maximum = Decimal.MaxValue;
            numericUpDown34.Maximum = Decimal.MaxValue;
            numericUpDown35.Maximum = Decimal.MaxValue;
            numericUpDown36.Maximum = Decimal.MaxValue;
            numericUpDown37.Maximum = Decimal.MaxValue;
            numericUpDown38.Maximum = Decimal.MaxValue;
            numericUpDown39.Maximum = Decimal.MaxValue;

            numericUpDown1.Minimum = Decimal.MinValue;
            numericUpDown2.Minimum = Decimal.MinValue;
            numericUpDown3.Minimum = Decimal.MinValue;
            numericUpDown4.Minimum = Decimal.MinValue;
            numericUpDown5.Minimum = Decimal.MinValue;
            numericUpDownColPosX.Minimum = Decimal.MinValue;
            numericUpDownColPosY.Minimum = Decimal.MinValue;
            numericUpDownColPosZ.Minimum = Decimal.MinValue;
            numericUpDownColRotX.Minimum = Decimal.MinValue;
            numericUpDownColRotY.Minimum = Decimal.MinValue;
            numericUpDownColRotZ.Minimum = Decimal.MinValue;
            numericUpDownColSclX.Minimum = Decimal.MinValue;
            numericUpDownColSclY.Minimum = Decimal.MinValue;
            numericUpDownColSclZ.Minimum = Decimal.MinValue;
            numericUpDownCamPosX.Minimum = Decimal.MinValue;
            numericUpDownCamPosY.Minimum = Decimal.MinValue;
            numericUpDownCamPosZ.Minimum = Decimal.MinValue;
            numericUpDownCamRotX.Minimum = Decimal.MinValue;
            numericUpDownCamRotY.Minimum = Decimal.MinValue;
            numericUpDownCamRotZ.Minimum = Decimal.MinValue;
            numericUpDown21.Minimum = Decimal.MinValue;
            numericUpDown22.Minimum = Decimal.MinValue;
            numericUpDown23.Minimum = Decimal.MinValue;
            numericUpDown24.Minimum = Decimal.MinValue;
            numericUpDown25.Minimum = Decimal.MinValue;
            numericUpDown26.Minimum = Decimal.MinValue;
            numericUpDown27.Minimum = Decimal.MinValue;
            numericUpDown28.Minimum = Decimal.MinValue;
            numericUpDown29.Minimum = Decimal.MinValue;
            numericUpDown30.Minimum = Decimal.MinValue;
            numericUpDown31.Minimum = Decimal.MinValue;
            numericUpDown32.Minimum = Decimal.MinValue;
            numericUpDown33.Minimum = Decimal.MinValue;
            numericUpDown34.Minimum = Decimal.MinValue;
            numericUpDown35.Minimum = Decimal.MinValue;
            numericUpDown36.Minimum = Decimal.MinValue;
            numericUpDown37.Minimum = Decimal.MinValue;
            numericUpDown38.Minimum = Decimal.MinValue;
            numericUpDown39.Minimum = Decimal.MinValue;
        }
        
        private void CameraEditor_Load(object sender, EventArgs e)
        {
            TopMost = true;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.WindowsShutDown) return;
            if (e.CloseReason == CloseReason.FormOwnerClosing) return;

            e.Cancel = true;
            Hide();
        }

        public string currentCameraFile;
        bool ProgramIsChangingStuff;
        int CurrentlySelectedCamera = -1;
                
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentCameraFile = null;
            ListBoxCameras.Items.Clear();
            toolStripStatusFile.Text = "No file loaded";
            LabelCameraCount.Text = "0 cameras";
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenCamera = new OpenFileDialog()
            {
                Filter = "BIN Files|*.bin"
            };
            if (OpenCamera.ShowDialog() == DialogResult.OK)
            {
                open(OpenCamera.FileName);
            }
        }

        public void open(string fileName)
        {
            currentCameraFile = fileName;

            ListBoxCameras.Items.Clear();
            ListBoxCameras.Items.AddRange(importCameraFile(currentCameraFile).ToArray());

            toolStripStatusFile.Text = "Loaded " + currentCameraFile;
            LabelCameraCount.Text = ListBoxCameras.Items.Count.ToString() + " cameras";

            ListBoxCameras.SelectedIndex = -1;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentCameraFile != null)
                saveCameraFile(currentCameraFile, ListBoxCameras.Items.Cast<CameraHeroes>());
            else
                saveAsToolStripMenuItem_Click(sender, e);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog SaveCamera = new SaveFileDialog()
            {
                Filter = "Binary Files|*.bin",
                FileName = currentCameraFile
            };
            if (SaveCamera.ShowDialog() == DialogResult.OK)
            {
                currentCameraFile = SaveCamera.FileName;
                saveCameraFile(currentCameraFile, ListBoxCameras.Items.Cast<CameraHeroes>());
            }
        }

        bool hasRemoved = false;

        private void ListBoxCameras_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProgramIsChangingStuff = true;

            if (!hasRemoved & CurrentlySelectedCamera != -1)
                (ListBoxCameras.Items[CurrentlySelectedCamera] as CameraHeroes).isSelected = false;
            else if (hasRemoved) hasRemoved = false;

            CurrentlySelectedCamera = ListBoxCameras.SelectedIndex;
            
            if (CurrentlySelectedCamera != -1)
            {
                try
                {
                    CameraHeroes current = ListBoxCameras.Items[CurrentlySelectedCamera] as CameraHeroes;

                    current.isSelected = true;

                    numericUpDown1.Value = current.CameraType;
                    numericUpDown2.Value = current.CameraSpeed;
                    numericUpDown3.Value = current.Integer3;
                    numericUpDown4.Value = current.ActivationType;
                    numericUpDown5.Value = current.TriggerShape;
                    numericUpDownColPosX.Value = (decimal)current.TriggerPosition.X;
                    numericUpDownColPosY.Value = (decimal)current.TriggerPosition.Y;
                    numericUpDownColPosZ.Value = (decimal)current.TriggerPosition.Z;
                    numericUpDownColRotX.Value = (decimal)(current.TriggerRotX * (360f / 65536f));
                    numericUpDownColRotY.Value = (decimal)(current.TriggerRotY * (360f / 65536f));
                    numericUpDownColRotZ.Value = (decimal)(current.TriggerRotZ * (360f / 65536f));
                    numericUpDownColSclX.Value = (decimal)current.TriggerScale.X;
                    numericUpDownColSclY.Value = (decimal)current.TriggerScale.Y;
                    numericUpDownColSclZ.Value = (decimal)current.TriggerScale.Z;
                    numericUpDownCamPosX.Value = (decimal)current.CamPos.X;
                    numericUpDownCamPosY.Value = (decimal)current.CamPos.Y;
                    numericUpDownCamPosZ.Value = (decimal)current.CamPos.Z;
                    numericUpDownCamRotX.Value = (decimal)(current.CamRotX * (360f / 65536f));
                    numericUpDownCamRotY.Value = (decimal)(current.CamRotY * (360f / 65536f));
                    numericUpDownCamRotZ.Value = (decimal)(current.CamRotZ * (360f / 65536f));
                    numericUpDown21.Value = (decimal)current.PointA.X;
                    numericUpDown22.Value = (decimal)current.PointA.Y;
                    numericUpDown23.Value = (decimal)current.PointA.Z;
                    numericUpDown24.Value = (decimal)current.PointB.X;
                    numericUpDown25.Value = (decimal)current.PointB.Y;
                    numericUpDown26.Value = (decimal)current.PointB.Z;
                    numericUpDown27.Value = (decimal)current.PointC.X;
                    numericUpDown28.Value = (decimal)current.PointC.Y;
                    numericUpDown29.Value = (decimal)current.PointC.Z;
                    numericUpDown30.Value = current.Integer30;
                    numericUpDown31.Value = current.Integer31;
                    numericUpDown32.Value = (decimal)current.FloatX32;
                    numericUpDown33.Value = (decimal)current.FloatY33;
                    numericUpDown34.Value = (decimal)current.FloatX34;
                    numericUpDown35.Value = (decimal)current.FloatY35;
                    numericUpDown36.Value = current.Integer36;
                    numericUpDown37.Value = current.Integer37;
                    numericUpDown38.Value = current.Integer38;
                    numericUpDown39.Value = current.Integer39;
                }
                catch
                {
                    MessageBox.Show("Could not load this camera properly: one or more properties are unsupported.");
                }
            }

            LabelCameraCount.Text = "Camera " + (CurrentlySelectedCamera + 1).ToString() + "/" + ListBoxCameras.Items.Count.ToString();

            ProgramIsChangingStuff = false;
        }

        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!ProgramIsChangingStuff & CurrentlySelectedCamera != -1)
            {
                CameraHeroes current = ListBoxCameras.Items[CurrentlySelectedCamera] as CameraHeroes;

                current.CameraType = (int)numericUpDown1.Value;
                current.CameraSpeed = (int)numericUpDown2.Value;
                current.Integer3 = (int)numericUpDown3.Value;
                current.ActivationType = (int)numericUpDown4.Value;
                current.TriggerShape = (int)numericUpDown5.Value;
                current.TriggerPosition = new Vector3((float)numericUpDownColPosX.Value, (float)numericUpDownColPosY.Value, (float)numericUpDownColPosZ.Value);
                current.TriggerRotX = ReadWriteCommon.DegreesToBAMS((float)numericUpDownColRotX.Value);
                current.TriggerRotY = ReadWriteCommon.DegreesToBAMS((float)numericUpDownColRotY.Value);
                current.TriggerRotZ = ReadWriteCommon.DegreesToBAMS((float)numericUpDownColRotZ.Value);
                current.TriggerScale = new Vector3((float)numericUpDownColSclX.Value, (float)numericUpDownColSclY.Value, (float)numericUpDownColSclZ.Value);
                current.CamPos = new Vector3((float)numericUpDownCamPosX.Value, (float)numericUpDownCamPosY.Value, (float)numericUpDownCamPosZ.Value);
                current.CamRotX = ReadWriteCommon.DegreesToBAMS((float)numericUpDownCamRotX.Value);
                current.CamRotY = ReadWriteCommon.DegreesToBAMS((float)numericUpDownCamRotY.Value);
                current.CamRotZ = ReadWriteCommon.DegreesToBAMS((float)numericUpDownCamRotZ.Value);
                current.PointA = new Vector3((float)numericUpDown21.Value, (float)numericUpDown22.Value, (float)numericUpDown23.Value);
                current.PointB = new Vector3((float)numericUpDown24.Value, (float)numericUpDown25.Value, (float)numericUpDown26.Value);
                current.PointC = new Vector3((float)numericUpDown27.Value, (float)numericUpDown28.Value, (float)numericUpDown29.Value);
                current.Integer30 = (int)numericUpDown30.Value;
                current.Integer31 = (int)numericUpDown31.Value;
                current.FloatX32 = (float)numericUpDown32.Value;
                current.FloatY33 = (float)numericUpDown33.Value;
                current.FloatX34 = (float)numericUpDown34.Value;
                current.FloatY35 = (float)numericUpDown35.Value;
                current.Integer36 = (int)numericUpDown36.Value;
                current.Integer37 = (int)numericUpDown37.Value;
                current.Integer38 = (int)numericUpDown38.Value;
                current.Integer39 = (int)numericUpDown39.Value;
                current.CreateTransformMatrix();

                ListBoxCameras.Items[CurrentlySelectedCamera] = current;
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            CameraHeroes newCamera = new CameraHeroes() { TriggerPosition = SharpRenderer.Camera.GetPosition() };
            ListBoxCameras.Items.Add(newCamera);
            ListBoxCameras.SelectedIndex = ListBoxCameras.Items.Count - 1;
            LabelCameraCount.Text = "Camera " + (CurrentlySelectedCamera + 1).ToString() + "/" + ListBoxCameras.Items.Count.ToString();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            int Save = CurrentlySelectedCamera;

            if (CurrentlySelectedCamera != -1)
            {
                hasRemoved = true;
                ListBoxCameras.Items.RemoveAt(CurrentlySelectedCamera);
                
                if (ListBoxCameras.Items.Count > 0)
                    LabelCameraCount.Text = "Camera " + (CurrentlySelectedCamera + 1).ToString() + "/" + ListBoxCameras.Items.Count.ToString();
                else
                    LabelCameraCount.Text = "0 cameras";

                if (Save < ListBoxCameras.Items.Count)
                    ListBoxCameras.SelectedIndex = Save;
                else
                    ListBoxCameras.SelectedIndex = ListBoxCameras.Items.Count - 1;
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            hasRemoved = true;
            ListBoxCameras.Items.Clear();
            LabelCameraCount.Text = "0 cameras";
        }

        private void buttonTeleportToTrigger_Click(object sender, EventArgs e)
        {
            if (!Teleport((float)numericUpDownColPosX.Value, (float)numericUpDownColPosY.Value, (float)numericUpDownColPosZ.Value))
                MessageBox.Show("Error writing data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void buttonGetTrigger_Click(object sender, EventArgs e)
        {
            if (Program.MemManager.ProcessIsAttached)
            {
                DeterminePointers();
                numericUpDownColPosX.Value = (decimal)Program.MemManager.ReadFloat(Pointer0X);
                numericUpDownColPosY.Value = (decimal)Program.MemManager.ReadFloat(Pointer0Y);
                numericUpDownColPosZ.Value = (decimal)Program.MemManager.ReadFloat(Pointer0Z);
            }
            else MessageBox.Show("Error reading data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void buttonGetCamera_Click(object sender, EventArgs e)
        {
            if (Program.MemManager.ProcessIsAttached)
            {
                DeterminePointers();
                numericUpDownCamPosX.Value = (decimal)Program.MemManager.ReadFloat(Camera_X);
                numericUpDownCamPosY.Value = (decimal)Program.MemManager.ReadFloat(Camera_Y);
                numericUpDownCamPosZ.Value = (decimal)Program.MemManager.ReadFloat(Camera_Z);
            }
            else MessageBox.Show("Error reading data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void buttonGetA_Click(object sender, EventArgs e)
        {
            if (Program.MemManager.ProcessIsAttached)
            {
                DeterminePointers();
                numericUpDown21.Value = (decimal)Program.MemManager.ReadFloat(Pointer0X);
                numericUpDown22.Value = (decimal)Program.MemManager.ReadFloat(Pointer0Y);
                numericUpDown23.Value = (decimal)Program.MemManager.ReadFloat(Pointer0Z);
            }
            else MessageBox.Show("Error reading data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void buttonGetB_Click(object sender, EventArgs e)
        {
            if (Program.MemManager.ProcessIsAttached)
            {
                DeterminePointers();
                numericUpDown24.Value = (decimal)Program.MemManager.ReadFloat(Pointer0X);
                numericUpDown25.Value = (decimal)Program.MemManager.ReadFloat(Pointer0Y);
                numericUpDown26.Value = (decimal)Program.MemManager.ReadFloat(Pointer0Z);
            }
            else MessageBox.Show("Error reading data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void buttonGetC_Click(object sender, EventArgs e)
        {
            if (Program.MemManager.ProcessIsAttached)
            {
                DeterminePointers();
                numericUpDown27.Value = (decimal)Program.MemManager.ReadFloat(Pointer0X);
                numericUpDown28.Value = (decimal)Program.MemManager.ReadFloat(Pointer0Y);
                numericUpDown29.Value = (decimal)Program.MemManager.ReadFloat(Pointer0Z);
            }
            else MessageBox.Show("Error reading data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
                
        private void buttonComeHere_Click(object sender, EventArgs e)
        {
            SharpRenderer.Camera.SetPosition(new Vector3((float)numericUpDownCamPosX.Value, (float)numericUpDownCamPosY.Value, (float)numericUpDownCamPosZ.Value));
        }

        private void buttonComeTrigger_Click(object sender, EventArgs e)
        {
            SharpRenderer.Camera.SetPosition(new Vector3((float)numericUpDownColPosX.Value, (float)numericUpDownColPosY.Value, (float)numericUpDownColPosZ.Value));
        }

        private void buttonGetView_Click(object sender, EventArgs e)
        {
            numericUpDownCamPosX.Value = (decimal)SharpRenderer.Camera.GetPosition().X;
            numericUpDownCamPosY.Value = (decimal)SharpRenderer.Camera.GetPosition().Y;
            numericUpDownCamPosZ.Value = (decimal)SharpRenderer.Camera.GetPosition().Z;
        }

        public void RenderAllCameras()
        {
            foreach (CameraHeroes c in ListBoxCameras.Items)
                if (SharpRenderer.frustum.Intersects(ref c.boundingBox))
                    c.Draw();
        }

        public void ScreenClicked(Ray r)
        {
            int index = ListBoxCameras.SelectedIndex;

            float smallerDistance = 10000f;
            for (int i = 0; i < ListBoxCameras.Items.Count; i++)
            {
                if (((CameraHeroes)ListBoxCameras.Items[i]).isSelected) continue;

                float? distance = ((CameraHeroes)ListBoxCameras.Items[i]).IntersectsWith(r);
                if (distance != null)
                    if (distance < smallerDistance)
                        index = i;
            }

            ListBoxCameras.SelectedIndex = index;
        }
    }
}