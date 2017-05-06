using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

using DbBank;

namespace SearchBanks
{
    public partial class MapForm : Form
    {
        private MainForm mdiParent;
        private GMapOverlay markersOverlayRed;
        private GMapOverlay markersOverlayGreen;
        private GMapMarkerGoogleGreen markerG;

        public MapForm()
        {
            InitializeComponent();
        }

        private void MapForm_Load(object sender, EventArgs e)
        {
            mdiParent = (MainForm)this.MdiParent;
            //Настройки для компонента GMap.
            gMapControl1.Bearing = 0;

            //CanDragMap - Если параметр установлен в True,
            //пользователь может перетаскивать карту 
            ///с помощью правой кнопки мыши. 
            gMapControl1.CanDragMap = true;

            //Указываем что перетаскивание карты осуществляется 
            //с использованием левой клавишей мыши.
            //По умолчанию - правая.
            gMapControl1.DragButton = MouseButtons.Left;

            gMapControl1.GrayScaleMode = true;

            //MarkersEnabled - Если параметр установлен в True,
            //любые маркеры, заданные вручную будет показаны.
            //Если нет, они не появятся.
            gMapControl1.MarkersEnabled = true;

            //Указываем значение максимального приближения.
            gMapControl1.MaxZoom = 18;

            //Указываем значение минимального приближения.
            gMapControl1.MinZoom = 2;

            //Устанавливаем центр приближения/удаления
            //курсор мыши.
            gMapControl1.MouseWheelZoomType =
                GMap.NET.MouseWheelZoomType.MousePositionAndCenter;

            //Отказываемся от негативного режима.
            gMapControl1.NegativeMode = false;

            //Разрешаем полигоны.
            gMapControl1.PolygonsEnabled = true;

            //Разрешаем маршруты.
            gMapControl1.RoutesEnabled = true;

            //Скрываем внешнюю сетку карты
            //с заголовками.
            gMapControl1.ShowTileGridLines = false;

            //Указываем, что при загрузке карты будет использоваться 
            //18ти кратной приближение.
            // gMapControl1.Zoom = 18;

            //Указываем, что все края элемента управления
            //закрепляются у краев содержащего его элемента
            //управления(главной формы), а их размеры изменяются 
            //соответствующим образом.
            gMapControl1.Dock = DockStyle.Fill;

            //Указываем, что будем использовать карты Google.
            gMapControl1.MapProvider =
                GMap.NET.MapProviders.GMapProviders.OpenStreetMap;
            GMap.NET.GMaps.Instance.Mode =
                GMap.NET.AccessMode.ServerOnly;

            //Если вы используете интернет через прокси сервер,
            //указываем свои учетные данные.
            GMap.NET.MapProviders.GMapProvider.WebProxy =
                System.Net.WebRequest.GetSystemWebProxy();
            GMap.NET.MapProviders.GMapProvider.WebProxy.Credentials =
                System.Net.CredentialCache.DefaultCredentials;
            
            gMapControl1.Position = new GMap.NET.PointLatLng(53.8838069, 27.4548928);
            markersOverlayRed = new GMapOverlay(gMapControl1, "markerRed");
            markersOverlayGreen = new GMapOverlay(gMapControl1, "markerGreen");
            List<Atm> atm = mdiParent.DBConnect.GetAllAtm();
            ShowRedMarkers(atm);

            gMapControl1.Overlays.Add(markersOverlayRed);  
        }

        private void gMapControl1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (markerG != null)
                {
                    markersOverlayGreen.Markers.Remove(markerG);
                }
                double X = gMapControl1.FromLocalToLatLng(e.X, e.Y).Lng;
                double Y = gMapControl1.FromLocalToLatLng(e.X, e.Y).Lat;
                markerG = new GMapMarkerGoogleGreen(new GMap.NET.PointLatLng(Y, X));
                markerG.ToolTip =
                    new GMap.NET.WindowsForms.ToolTips.GMapRoundedToolTip(markerG);
                markerG.ToolTipText = "Я";
                markersOverlayGreen.Markers.Add(markerG);
                gMapControl1.Overlays.Add(markersOverlayGreen);
            }
        }

        public void UpdateMapFiler(List<Atm> atm)
        {
            gMapControl1.Overlays.Clear();
            markersOverlayRed.Markers.Clear();
            this.Update();
            ShowRedMarkers(atm);
            gMapControl1.Overlays.Add(markersOverlayGreen);
            gMapControl1.Overlays.Add(markersOverlayRed);  
        }

        public void ClosestObjects()
        {
            if (markerG != null)
            {
                gMapControl1.Overlays.Clear();
                markersOverlayRed.Markers.Clear();
                this.Update();
                List<Atm> atm = mdiParent.DBConnect.GetAllClosestAtm(markerG.Position.Lat, markerG.Position.Lng, mdiParent.Num);
                ShowRedMarkers(atm);
                gMapControl1.Overlays.Add(markersOverlayGreen);
                gMapControl1.Overlays.Add(markersOverlayRed);  
            }
            else
            {
                MessageBox.Show("Укажите на карте ваше местоположение правой кнопкой мыши");
            }
        }

        public void ShowAllRedMarkers()
        {
            gMapControl1.Overlays.Clear();
            markersOverlayRed.Markers.Clear();
            this.Update();
            List<Atm> atm = mdiParent.DBConnect.GetAllAtm();
            ShowRedMarkers(atm);
            gMapControl1.Overlays.Add(markersOverlayRed);  
        }

        private void ShowRedMarkers(List<Atm> atm)
        {
            foreach (Atm item in atm)
            {
                GMapMarkerGoogleRed markerR =
                    new GMapMarkerGoogleRed(new GMap.NET.PointLatLng(item.gpsX, item.gpsY));
                markerR.ToolTip =
                    new GMap.NET.WindowsForms.ToolTips.GMapBaloonToolTip(markerR);
                //Текст отображаемый при наведении на маркер.
                markerR.ToolTipText = item.Bank.name + "\r\n";
                markerR.ToolTipText += item.title + "\r\n";
                markerR.ToolTipText += item.phone + "\r\n";
                markerR.ToolTipText += item.addressatm + "\r\n";
                markerR.ToolTipText += "USD: " + item.Bank.usdbuy + ", " + item.Bank.usdsell + " \r\n";
                markerR.ToolTipText += "EUR: " + item.Bank.eurbuy + ", " + item.Bank.eursell + " \r\n";
                markerR.ToolTipText += "RUR: " + item.Bank.rurbuy + ", " + item.Bank.rursell + " \r\n";
                markersOverlayRed.Markers.Add(markerR);
            }
        }

        public void UpdateMinMaxRates()
        {
            gMapControl1.Overlays.Clear();
            markersOverlayRed.Markers.Clear();
            this.Update();
            List<Bank> banks = mdiParent.DBConnect.GetMinMaxRates(mdiParent.SearchMinMaxRates, mdiParent.Num);
            List<Atm> atm = new List<Atm>();
            foreach (Bank bn in banks)
            {
                foreach (Atm at in bn.Atm) 
                {
                    atm.Add(at);
                }
            }
            ShowRedMarkers(atm);
            gMapControl1.Overlays.Add(markersOverlayRed);  
        }

        private void MapForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            mdiParent.MapForm = null;
        }


    }
}
