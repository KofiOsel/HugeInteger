using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HugeInteger
{
    class HugeInteger
    {
        public int[] hugeDig = new int[40];
        public int count = 0;

        public HugeInteger()
        {
            for (int i = 0; i < 40; i++)
            {
                hugeDig[i] = 0;
            }
        }

        public void Input(string userInput)
        {
            count = userInput.Length;
            char[] charConv = userInput.PadLeft(40, '0').ToCharArray();
            for (int i = 0; i < 40; i++)
            {
                hugeDig[i] = (int)Char.GetNumericValue(charConv[i]); // Storing the int value in the array
            }
        }

        public override string ToString()
        {
            string str = "";
            int num = hugeDig.Length - count;

            for (int i = 0; i < 40; i++)
            {
                if (i >= num)
                {
                    str = str + hugeDig[i];
                }
            }
            return str;
        }

        public string Add(HugeInteger otherNum)
        {
            string str1 = this.ToString();
            string str2 = otherNum.ToString();
           
            StringBuilder sb = new StringBuilder();
            int carry = 0;
            int i = str1.Length - 1;
            int k = str2.Length - 1;
            int total = 0;

            while (i > -1 || k > -1)
            {
                if (i < 0) // This the first if statement
                {
                    total = carry + 0;
                } else
                {
                    total = carry + str1[i--] - 48; // 1) I will start by adding the first i int the total varialble
                }

                if (k < 0) // This is the second if statement
                {
                    total += 0;
                    sb.Append(total % 10);
                    carry = total / 10;
                }
                else
                {
                    total += str2[k--] - 48; // 2) I add J in the total variable to sum i and j up
                    sb.Append(total % 10); // this calculation is to check if there is a carray 
                    carry = total / 10; // once I extract the carry I will use that number to add it in the next calculation
                }
            }

            sb.Append(carry == 1 ? "1" : "");
            string s = sb.ToString(); // transforming the thenumbers in the string builder into toString
            string finalAns = "";
            for (int f = s.Length - 1; f >= 0; f--)
            {
                finalAns += s[f]; // I am stroring does numbers in the variable finalAns
            }
            return finalAns;
        }

        public string Substract(HugeInteger otherNum)
        {
            var str1 = this.ToString();
            var str2 = otherNum.ToString();
            string temp;

            if (str1.Length < str2.Length)
            {
                temp = this.ToString();
                str1 = otherNum.ToString();
                str2 = temp;
            }

            StringBuilder sb = new StringBuilder(str1);
            int i = str1.Length - 1;
            int j = str2.Length - 1;
            int total = 0;
            int numm1 = 0;
            int numm2 = 0;
            int tempp = 0;
            string totalfi = "";
            int carry = 0;
            int souv = 0;
            bool cond = true;
            int temp2 = 0;

            while (i > -1 || j > -1)
            {
                numm1 = (sb[i] - 48) - carry;
                if (!(j < 0))
                {
                    numm2 = str2[j] - 48;
                }

                if (numm1 >= numm2) // if the digit in numm1 is bigger than the digit in numm2 run this if statement
                {
                    total = numm1 - numm2;
                    totalfi += total.ToString();
                    carry = 0;
                    cond = false;
                }
                else
                {
                    numm1 += 10;
                    souv = i;
                    if (!((sb[i - 1] - 48) == 0))
                    {
                        temp2 = (sb[i - 1] - 48) - 1;
                        string h = temp2.ToString();
                        char c = char.Parse(h);
                        sb[i - 1] = c;
                    }

                    if (((sb[i - 1] - 48) == 0))
                    {
                        total = numm1 - numm2;
                        totalfi += total.ToString();
                        cond = false;

                        for (int t = i - 1; t < sb.Length; t--)
                        {
                            if ((sb[t] - 48) > 0) // If the borrow number is bigger than 0 run this if statement
                            {
                                tempp = (sb[t] - 48) - 1;
                                string h = tempp.ToString();
                                char c = char.Parse(h);
                                sb[t] = c;
                                t = sb.Length + 2;
                                continue;

                            }
                            if ((sb[t] - 48) == 0) //if the borrowing number is equal 0 change it to 9
                            {
                                sb[t] = '9';
                            }
                        }
                    }


                }
                if (cond == true)
                {
                    total = numm1 - numm2; // Calculating numm1 minus numm2
                    totalfi += total.ToString(); // adding the result of numm1 minus numm2 in the string
                    --i;
                    --j;
                }
                numm2 = 0;
                if (cond == false)
                {
                    --i;
                    --j;
                }
                cond = true;


            }

            string start = "";
            for (int f = totalfi.Length - 1; f >= 0; f--)
            {
                start += totalfi[f];
            }
            return start;
        }

        public string Multiple(HugeInteger otherNum)
        {
            var str1 = this.ToString();
            var str2 = otherNum.ToString();
            string temp;

            if (str1.Length > str2.Length)
            {
                temp = this.ToString();
                str1 = otherNum.ToString();
                str2 = temp;
            }

            StringBuilder sb = new StringBuilder();
            int cont = 0;
            int carry = 0;
            int i = str1.Length - 1;
            int j = str2.Length - 1;
            int total = 0;
            int totalTemp = 0;
            int holder = 0;
            int first = 0;
            int first2 = 0;
            string ultaFinal = "";
            int remainder = 0;
            string[] zero = new string[] { "0" };
            string[] num = new string[str1.Length];


            for (int r = str1.Length - 1; r >= 0; r--) // Doing a nested for loop
            {
                holder = str1[r] - 48;
                for (int w = str2.Length - 1; w >= 0; w--) //multiplying the first digit of the second number by the first number
                {
                    if (first > 0)
                    {
                        for (int z = 0; z < first; z++)
                        {
                            ultaFinal += zero[0];
                        }
                    }
                    first = 0;
                    totalTemp += holder * (str2[w] - 48);
                    remainder = totalTemp % 10;
                    carry = totalTemp / 10;
                    ultaFinal += remainder.ToString();
                    totalTemp = 0;
                    totalTemp = totalTemp + carry;

                    if (w == 0)
                    {
                        if (totalTemp < 1)
                        {
                            num[cont++] = ultaFinal;
                            totalTemp = 0;
                            ultaFinal = "";
                            ++first;
                            ++first2;
                            first = first2;
                            break;
                        }
                        else
                        {
                            ultaFinal += totalTemp.ToString(); 
                            num[cont++] = ultaFinal; // Storing each number in the array
                            totalTemp = 0;
                            ultaFinal = "";
                            ++first;
                            ++first2;
                            first = first2;
                        }
                    }
                    carry = 0;
                }
            }

            string tmp2 = "";
            for (int k = 0; k < num.Length; k++)
            {
                string tmp = num[k];
                for (int q = tmp.Length - 1; q >= 0; q--)
                {
                    tmp2 += tmp[q];
                }
                num[k] = tmp2;
                tmp2 = "";
            }

            var addResult = new HugeInteger();
            var addResult2 = new HugeInteger();
            var addResult3 = new HugeInteger();
            var tr = new HugeInteger();
            var finalAns = "";
            var d = "";
            addResult.Input("0");
            for (int t = 0; t < num.Length; t++)
            {
                finalAns = num[t];
                addResult2.Input(finalAns);
                finalAns = addResult.Add(addResult2);
                addResult.Input(finalAns);

            }
            return finalAns;
        }

        public Boolean isZero(HugeInteger otherNum)
        {
            var str1 = this.ToString();
            var str2 = otherNum.ToString();

            if (str1.Equals("0") && str2.Equals("0"))
            {
                return true;
            }
            return false;
        }

        public string Divide(HugeInteger otherNum)
        {
            var str1 = this.ToString();
            var str2 = otherNum.ToString();
            HugeInteger hugeCount = new HugeInteger();
            HugeInteger increment = new HugeInteger();
            hugeCount.Input("0");
            increment.Input("1");
            string g = "";
            var f = "";

            while (this.IsGreaterThanOrEqualTo(otherNum))
            {
                if (f.Equals("0"))
                {
                    break;
                }
                f = this.Substract(otherNum);

                g = hugeCount.Add(increment);

                this.Input(f);
                hugeCount.Input(g);

            }
            return g;
        }

        public string Remainder(HugeInteger otherNum)
        {
            var str1 = this.ToString();
            var str2 = otherNum.ToString();

            HugeInteger hugeCount = new HugeInteger();
            HugeInteger increment = new HugeInteger();
            hugeCount.Input("0");
            increment.Input("1");
            string g = "";
            var f = "";
            while (this.IsGreaterThanOrEqualTo(otherNum))
            {
                f = this.Substract(otherNum);
                g = hugeCount.Add(increment);
                this.Input(f);
                hugeCount.Input(g);

            }

            string start = "";
            for (int q = f.Length - 1; q >= 0; q--)
            {
                start += f[q];
            }
            return start;
        }

        public Boolean isEqualTo(HugeInteger otherNum)
        {
            var str1 = this.ToString();
            var str2 = otherNum.ToString();
            if (str1.Equals(str2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean isNotEqualTo(HugeInteger otherNum)
        {
            var str1 = this.ToString();
            var str2 = otherNum.ToString();
            if (!str1.Equals(str2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean IsGreaterThan(HugeInteger otherNum)
        {
            var str1 = this.ToString();
            var str2 = otherNum.ToString();
            int first = 0;
            int second = 0;

            if (str1.Length > str2.Length)
            {
                return true;
            }
            else if (str2.Length > str1.Length)
            {
                return false;
            }

            for (int i = 0; i < str1.Length; i++)
            {
                first = (int)(str1[i] - '0');
                second = (int)(str2[i] - '0');

                if (first > second)
                {
                    return true;
                }
                else if (second > first)
                {
                    return false;
                }
            }
            return false;
        }

        public Boolean IsLessThan(HugeInteger otherNum)
        {
            var str1 = this.ToString();
            var str2 = otherNum.ToString();
            int first = 0;
            int second = 0;

            if (str1.Length < str2.Length)
            {
                return true;
            }
            else if (str2.Length > str1.Length)
            {
                return false;
            }

            for (int i = 0; i < str1.Length; i++)
            {
                first = (int)(str1[i] - '0');
                second = (int)(str2[i] - '0');

                if (first < second)
                {
                    return true;
                }
                else if (second < first)
                {
                    return false;
                }
            }
            return false;
        }

        public Boolean IsGreaterThanOrEqualTo(HugeInteger otherNum)
        {
            var str1 = this.ToString();
            var str2 = otherNum.ToString();
            int firstNum = 0;
            int secondNum = 0;

            if (str1.Length > str2.Length)
            {
                return true;
            }
            else if (str2.Length > str1.Length)
            {
                return false;
            }


            if (str1.Length == str2.Length)
            {
                firstNum = str1[0] - 48;
                secondNum = str2[0] - 48;
                bool cond = true;
                for (int i = 0; i < str2.Length; i++)
                {
                    firstNum = str1[i] - 48;
                    secondNum = str2[i] - 48;
                    if (firstNum > secondNum)
                    {
                        return true;
                    }
                    else if (firstNum == secondNum)
                    {
                        cond = false;
                        continue;
                    }
                    else if (firstNum < secondNum && cond == false)
                    {
                        return false;
                    }
                    else if (firstNum < secondNum)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public Boolean IsLessThanOrEqualTo(HugeInteger otherNum)
        {
            return !IsGreaterThan(otherNum);
        }
    }
}
  

           

      


 