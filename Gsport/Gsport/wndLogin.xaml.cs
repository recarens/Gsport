﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Gsport
{
    /// <summary>
    /// Lógica de interacción para wndLogin.xaml
    /// </summary>
    public partial class wndLogin : Window
    {
        efadbDataSet dataSetAux;
        public int codiUsuari;
        public int privilegi;
        int nErrors = 0;
        public wndLogin()
        {
            InitializeComponent();
        }
        public wndLogin(efadbDataSet dataSet)
        { 
            InitializeComponent();
            dataSetAux = dataSet;
        }

        /// <summary>
        /// Fa una mira si hi ha un usuari amb el nom del texbox i despres mira que la password sigui correcte
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            bool trobat = false;
            foreach (DataRow Linia in dataSetAux.usuaris.Rows)
            {
                if (tbUsuari.Text.Trim() == Linia["username"].ToString().Trim())
                    if (pbContrasenya.Password.Trim() == Linia["password"].ToString().Trim())
                    {
                        trobat = true;
                        codiUsuari = (int)Linia["id_usuari"];
                        privilegi = (int)Linia["id_rol"];
                    }
            }
            if (trobat)
            {
                this.Close();
            }
            else
            {
                nErrors++;
                
                if(nErrors >= 5)
                {
                    MessageBox.Show("T'has equivocat molts cops");
                }
                else
                    MessageBox.Show("No és correcte");
            }
        }

        /// <summary>
        /// canvia l'idioma a catala
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void imgCat_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("ca-ES");
            idiomes.WrapperIdiomes.ChangeCulture(Thread.CurrentThread.CurrentUICulture);       
        }

        /// <summary>
        /// canvia l'idioma a ingles
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void imgEn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-GB");
            idiomes.WrapperIdiomes.ChangeCulture(Thread.CurrentThread.CurrentUICulture);

        }

        /// <summary>
        /// canvia l'idioma a espanyol
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void imgEs_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-ES");
            idiomes.WrapperIdiomes.ChangeCulture(Thread.CurrentThread.CurrentUICulture);

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
