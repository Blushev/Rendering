using System;
using System.Collections.Generic;
using System.Text;

namespace Rendering
{
    public class CountSumm
    {
        List<double> numbers = new List<double>();
        public double GetSummRangeX(string[] _text)
        {
                for (int i = 0; i < _text.Length; i++)
                {
                    double number;
                    if (double.TryParse(_text[i], out number))
                        numbers.Add(number);
                else
                    {
                        switch (_text[i])
                        {
                            case "+":
                                {
                                    double summ = numbers[numbers.Count - 1] + numbers[numbers.Count - 2];
                                    numbers.RemoveAt(numbers.Count - 1);
                                    numbers.RemoveAt(numbers.Count - 1);
                                    numbers.Add(summ);
                                    break;
                                }
                            case "-":
                                {
                                    double summ = numbers[numbers.Count - 1] - numbers[numbers.Count - 2];
                                    numbers.RemoveAt(numbers.Count - 1);
                                    numbers.RemoveAt(numbers.Count - 1);
                                    numbers.Add(summ);
                                    break;
                                }
                            case "*":
                                {
                                    double summ = numbers[numbers.Count - 1] * numbers[numbers.Count - 2];
                                    numbers.RemoveAt(numbers.Count - 1);
                                    numbers.RemoveAt(numbers.Count - 1);
                                    numbers.Add(summ);
                                    break;
                                }
                            case "/":
                                {
                                    double summ = numbers[numbers.Count - 1] / numbers[numbers.Count - 2];
                                    numbers.RemoveAt(numbers.Count - 1);
                                    numbers.RemoveAt(numbers.Count - 1);
                                    numbers.Add(summ);
                                    break;
                                }
                            case "^":
                                {
                                    double summ = Math.Pow(numbers[numbers.Count - 2], numbers[numbers.Count - 1]);
                                    numbers.RemoveAt(numbers.Count - 1);
                                    numbers.RemoveAt(numbers.Count - 1);
                                    numbers.Add(summ);
                                break;
                                }

                        }
                    }
                }
            return numbers[0];
        }
    }
}
