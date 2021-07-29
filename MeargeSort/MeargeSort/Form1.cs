using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MeargeSort
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int[] a = { 22,19,6,14, 10,4 };
            
            sortmerge(a,0,a.Length-1);
            string sortarray="";
            for(int i =0;i<=a.Length-1;i++ )
            {
                
                sortarray = (sortarray=="" ? sortarray+a[i] : sortarray + "," + a[i]);
            }
            MessageBox.Show(sortarray);
            this.Close();
            //int[] a = { 6, 10, 12, 14,15 };
            //int[] b = {1,7,13,20,25};
            //merge(a, b);
        }

        private void merge(int[] arr1,int[] arr2)
        {
            int[] result = new int[10];
            
            int m=0,n=0,i=0,j=0,k=0;

            m = arr1.Count();
            n = arr2.Count();
            while(i< m && j< n )
            {
                if(arr1[i]<arr2[j])
                {
                    result[k] = arr1[i];
                    k++;i++;
                }
                else
                {
                    result[k] = arr2[j];
                    k++; j++;
                }
            }
            while(i<m)
            {
                result[k] = arr1[i];
                k++;i++;
            }
            while (j < n)
            {
                result[k] = arr2[j];
                k++; j++;
            }
            string msg="";
            foreach(var item in result )
            {
                msg = msg+","+item.ToString();

                }
            MessageBox.Show("sorted array= "+ msg.ToString());

        }

        private void sortmerge(int[] arr,int left, int right)
        {
            int l, r, mid;
            if (right > left)
            {
                mid = (right + left) / 2;
                sortmerge(arr, left, mid);
                sortmerge(arr, (mid + 1), right);
                Mainmerge(arr,left,mid+1,right);

            }

        }
        private void Mainmerge (int[] numb,int left, int mid,int right )
        {
            int[] temp = new int[10];
            int i, eol, num, pos;
            eol = (mid - 1);
            pos = left;
            num = (right - left + 1);

            while((left<=eol) && (mid<= right))
            {
                if(numb[left]<= numb[mid])
                {
                    temp[pos++] = numb[left++];
                }
                else
                {
                    temp[pos++] = numb[mid++];
                }
            }
            while(left<=eol)
            {
                temp[pos++] = numb[left++];

            }
            while (mid <= right)
            {
                temp[pos++] = numb[mid++];

            }
            for(i=0;i< num;i++)
            {
                numb[right] = temp[right];
                right--;
            }
        }
    }
}
