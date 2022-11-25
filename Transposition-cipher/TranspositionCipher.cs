using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Transposition_cipher
{
    class Transposition
    {
        private int[] key = null;
        public bool isNumber(string s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] < '0' || s[i] > '9')
                {
                    return false;
                }
            }
            return true;
        }
        public int getiMax(string s)
        {
            int iMax = 0;
            for (int i = 1; i < s.Length; i++)
            {
                if (Convert.ToInt32(s[iMax]) < Convert.ToInt32(s[i]))
                {
                    iMax = i;
                }
            }
            return iMax;
        }
        public int getiNextMax(string s, int iMax)
        {
            int iNextMax = -1;
            bool flag = false;
            for (int i = 0; i < s.Length; i++)
            {
                if (Convert.ToInt32(s[i]) < Convert.ToInt32(s[iMax]))
                {
                    if(!flag)
                    {
                        flag = true;
                        iNextMax = i;
                    }
                    else
                    {
                        if (Convert.ToInt32(s[iNextMax]) < Convert.ToInt32(s[i]))
                        {
                            iNextMax = i;
                        }
                    }
                    
                }
            }
            return iNextMax;
        }
        public void SetKey(string s)
        {
            int iMax = getiMax(s);
            key = new int[s.Length];
            int n = s.Length;
            for (int i = n; i > 0; i--)
            {
                key[iMax] = i;
                iMax = getiNextMax(s, iMax);
            }
        }

        public string Encrypt(string input)
        {
            int[] _key = new int[key.Length];
            for (int i = 0; i < key.Length; i++)
            {
                _key[key[i] - 1] = i;
            }
            string result = "";
            for (int i = 0; i < _key.Length; i++)
            {
                for (int j = _key[i]; j < input.Length; j += _key.Length)
                {
                    result += input[j];
                }
            }
            return result;
        }

        public string Decrypt(string input)
        {
            int[] _key = new int[key.Length];
            for (int i = 0; i < key.Length; i++)
            {
                _key[key[i] - 1] = i;
            }
            int lack = (input.Length % key.Length);
            if(lack != 0)
            {
                lack = key.Length - lack;
            }
            int row = Convert.ToInt32(Math.Ceiling(1.0 * (input.Length + lack) / key.Length));
            int quota = key.Length - lack;
            string[] transposition = new string[key.Length];
            
            int j = 0;
            int resetRow = 0;
            for (int i = 0; i < _key.Length; i++)
            {
                transposition[_key[i]] = "";
                while(j < input.Length)
                {
                    resetRow++;
                    if (_key[i] > quota - 1 && resetRow == row)
                    {
                        transposition[_key[i]] += " ";
                        resetRow = 0;
                        break;
                    }
                    transposition[_key[i]] += input[j];
                    j++;
                    if(resetRow == row)
                    {
                        resetRow = 0;
                        break;
                    }
                }                
            }
            //return transposition[_key[1]];
            quota = 1;
            string result = "";
            for (int i = 0; i < row; i++)
            {
                for (j = 0; j < _key.Length; j++)
                {                    
                    result += transposition[j][i];
                    if (quota == input.Length)
                    {
                        quota++;
                        break;
                    }
                    quota++;
                }
            }
            return result;
        }
    }
}