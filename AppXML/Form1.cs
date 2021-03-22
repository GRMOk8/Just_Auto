﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using LibXML;

namespace AppXML
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            var path = @"C:\\Users\\Home\\Desktop\\bash fed\\Just Auto\\Just_Auto\\LibXML\\XML_Auto.xml";
            var data = Xml.LoadObjectFromFile<Root>(path);

            dataGridView1.DataSource = data.Children;
        }
    }
}
