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
    public partial class frm_brisanje : Form
    {
        private int _id;
        APIService _aPIService = new APIService("Narudzbe");
        public frm_brisanje(int id)
        {
            _id = id;
            InitializeComponent();
        }

        private async void frm_brisanje_Load(object sender, EventArgs e)
        {
            PretragaNarudzbiVM objekat = new PretragaNarudzbiVM
            {
                NazivNarudzbe = "Brisanje"
            };
            
            var obj = await _aPIService.Get<IList<IspisNarudzbi>>(objekat);

            string nazivnarudzbe = null;
            nazivnarudzbe=obj.Where(a => a.NarudzbaID == _id).Select(a => a.NazivNarudzbe).FirstOrDefault();
            if (nazivnarudzbe != null)
            {
                txt_nazivnarudzbe.Text = nazivnarudzbe;
            }
            else
            {
                MessageBox.Show("Ova narudžba više ne postoji u sistemu!", "Brisanje narudžbe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void btn_ne_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_da_Click(object sender, EventArgs e)
        {
            var obj = _aPIService.IzbrisiNarudzbu<Narudzba>(_id);

            MessageBox.Show("Uspješno ste izbrisali narudžbu!", "Brisanje narudžbe", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
