﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Collections.ObjectModel;
using System.Data;
//using System.Data.EntityClient;



namespace EquipMaintSys1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
   public partial class MainWindow : Window
    {
        static string conString = @"data source = 172.28.134.1; initial catalog = L00143846_EquiptMaintSys1; persist security info=True;user id = j.mcdaid; password=***********;pooling=False;MultipleActiveResultSets=True;App=EntityFramework";
        SqlConnection con = new SqlConnection(conString);
        #region -- VARIABLES
        // fault tab variables
        int fauB = 0;
        //admin tab variables
        int admB = 0;
        string admY = "z";
        #endregion -- VARIABLES
        public MainWindow()
        {
            InitializeComponent();
            cbo_Selection.Visibility = System.Windows.Visibility.Hidden;
            adminBtn.Visibility = System.Windows.Visibility.Hidden;
            cbo_Fault.Visibility = System.Windows.Visibility.Hidden;
            faultsBtn.Visibility = System.Windows.Visibility.Hidden;
            tbxFaultDetail.Visibility = System.Windows.Visibility.Hidden;
        }
        #region REGION -- EXIT TAB
        private void exitBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
            Environment.Exit(0);
        }
        #endregion EXIT TAB
        #region REGION -- ADMIN TAB
        #region adminTabBtnSecection
        private void queryBreakBtn_Click(object sender, RoutedEventArgs e)
        {
            admB = 1;
            cbo_Selection.Visibility = System.Windows.Visibility.Visible;
        }

        private void queryMaintBtn_Click(object sender, RoutedEventArgs e)
        {
            admB = 2;
            cbo_Selection.Visibility = System.Windows.Visibility.Visible;
        }

        private void queryCompBtn_Click(object sender, RoutedEventArgs e)
        {
            admB = 3;
            cbo_Selection.Visibility = System.Windows.Visibility.Visible;
        }

        private void queryUsersBtn_Click(object sender, RoutedEventArgs e)
        {
            admB = 4;
            cbo_Selection.Visibility = System.Windows.Visibility.Visible;
        }
        public void addBtn_Click(object sender, RoutedEventArgs e)
        {
            admB = 5;
            cbo_Selection.Visibility = System.Windows.Visibility.Visible;
            //con.Open();
            //SqlCommand commObject1 = new SqlCommand("select Name from Item", con);

            //// L00143846_EquiptMaintSys1Entities db = new L00143846_EquiptMaintSys1Entities();
            //// using (L00143846_EquiptMaintSys1Entities db = new L00143846_EquiptMaintSys1Entities())
            //try
            //{
            //    //SqlDataAdapter sda = new SqlDataAdapter("select Name from Item", con);
            //    SqlDataReader dr = commObject1.ExecuteReader();
            //    while (dr.Read())
            //    {
            //        //ListViewItem y = new ListViewItem(dr["Names"].ToString());
            //        //tblkOutput.ToString();
            //        //lbxOutput.ToString();
            //    }
            //    //DataTable dt = new DataTable();
            //    //sda.Fill(dt);
            //    //cbo_Selection.Items.Add(dt);
            //}// end try

            //catch (Exception ex)
            //{ MessageBox.Show(ex.Message); }// end catch

            //finally
            //{ con.Close(); }//end finally
        }

        private void archiveBtn_Click(object sender, RoutedEventArgs e)
        {
            admB = 6;
        }









        #endregion  adminTabBtnSecection


        #region ComboBox Selection Change
        private void cbo_Selection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            adminBtn.Visibility = System.Windows.Visibility.Visible;
          //  if (cbo_Selection_SelectionChanged

        }










        #endregion ComboBox Selection Change

        #endregion ADMIN TAB
        #region REGION -- FAULT TAB
        private void reportFaultBtn_Click(object sender, RoutedEventArgs e)
        {
            fauB = 1;
            cbo_Fault.Visibility = System.Windows.Visibility.Visible;

            //// L00143846_EquiptMaintSys1Entities db = new L00143846_EquiptMaintSys1Entities();
            //// using (L00143846_EquiptMaintSys1Entities db = new L00143846_EquiptMaintSys1Entities())
            try
            {
                con.Open();
                //SqlCommand commObject1 = new SqlCommand("select Name from Equiptment", con);
                SqlDataAdapter commObject1 = new SqlDataAdapter("select Name from Equiptment", con);
                DataTable dt = new DataTable();
                commObject1.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    listV_fault_data.Items.Add(row["Name"].ToString());
                }

                //    //SqlDataAdapter sda = new SqlDataAdapter("select Name from Item", con);
                //    SqlDataReader dr = commObject1.ExecuteReader();
                //    while (dr.Read())
                //    {
                //        //ListViewItem y = new ListViewItem(dr["Names"].ToString());
                //        //tblkOutput.ToString();
                //        //lbxOutput.ToString();
                //    }
                //    //DataTable dt = new DataTable();
                //    //sda.Fill(dt);
                //    //cbo_Selection.Items.Add(dt);
            }// end try

            catch (Exception ex)
            { MessageBox.Show(ex.Message); }// end catch

            finally
            { con.Close(); }//end finally

        }

        private void updateFaultBtn_Click(object sender, RoutedEventArgs e)
        {
            fauB = 2;
            cbo_Fault.Visibility = System.Windows.Visibility.Visible;

        }

        private void resolveFaultBtn_Click(object sender, RoutedEventArgs e)
        {
            fauB = 3;
            cbo_Fault.Visibility = System.Windows.Visibility.Visible;
        }        

        private void cbo_Fault_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            faultsBtn.Visibility = System.Windows.Visibility.Visible;
            tbxFaultDetail.Visibility = System.Windows.Visibility.Visible;

        }


        

        private void TabItem_Initialized(object sender, EventArgs e)
        {


        }
        

        private void tbxFaultDetail_GotFocus(object sender, RoutedEventArgs e)
        {
            tbxFaultDetail.Text = string.Empty;
        }
        #endregion FAULT TAB
    }// end main
}// end namespace

