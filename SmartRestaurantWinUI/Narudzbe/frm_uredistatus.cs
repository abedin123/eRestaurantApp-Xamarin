﻿using MobileApps;
using SmartRestaurant.Data;
using SmartRestaurant.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartRestaurantWinUI.Narudzbe
{
    public partial class frm_uredistatus : Form
    {
        APIService _aPIService = new APIService("Narudzbe");
        private int _id;

        public frm_uredistatus(int id)
        {
            InitializeComponent();
            _id = id;
        }

        private async void frm_uredistatus_Load(object sender, EventArgs e)
        {    
            var obj = await _aPIService.GetNarudzbaStatus<IzmjeniStatusNarudzbeVM>(_id);
            if (obj != null)
            {
                txt_narudzbanaziv.Text = obj.NazivNarudzbe;
                cmb_status.DisplayMember = "NazivStatusa";
                cmb_status.ValueMember = "StatusNarudzbeID";
                cmb_status.DataSource = obj.listastatusa;
            }
            else
            {
                MessageBox.Show("Ova narudžba više ne postoji u sistemu!", "Uredi status", MessageBoxButtons.OK);
                this.Close();
            }
        }

        private async void btn_sacuvaj_Click(object sender, EventArgs e)
        {
            StatusNarudzbeVM objekat = new StatusNarudzbeVM();
            objekat.NarudzbaID = _id;
            objekat.NazivStatusa = cmb_status.Text;

            await _aPIService.PromjenaStatusaNarudzbe<StatusNarudzbeVM>(objekat);
            
            MessageBox.Show("Uspješno promijenjen status narudžbe!", "Promjena statusa narudžbe", MessageBoxButtons.OK);
            this.Close();
        }
    }
}
