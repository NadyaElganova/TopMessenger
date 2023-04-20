using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopMessenger.Infastructure.Utils
{
    public enum ValidateType
    {
        EmptyStr,
        DigitContains,
        SpecialSymb,
        IsEmailValidate
    }

    public class ValidationUtils
    {
        private static event Func<string, bool> _validateEvent;

        public static bool Validate(string value, params ValidateType[] validateTypes)
        {
            if(validateTypes.Contains(ValidateType.EmptyStr)==true)
            {
                _validateEvent += EmptyStrValidate;   
            }
            if (validateTypes.Contains(ValidateType.IsEmailValidate)==true)
            {
                _validateEvent += EmailValidate;
            }
            if (validateTypes.Contains(ValidateType.DigitContains) == true)
            {
                _validateEvent += DigitContainsValidate;
            }
            if (validateTypes.Contains(ValidateType.SpecialSymb) == true)
            {
                _validateEvent += SymbContainsValidate;
            }
            if (_validateEvent != null)
            {
                return _validateEvent(value);
            }
            else 
            {
                return false;
            }
        }

        public static bool EmptyStrValidate(string value)
        {
            //if(string.IsNullOrWhiteSpace(value)) return false;
            //return true;
            
            return !string.IsNullOrWhiteSpace(value);
        }
        /// <summary>
        /// Значение явл-ся валидным если нет чисел
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>

        public static bool DigitContainsValidate(string value)
        {
            foreach (var item in value)
            {
                if (char.IsDigit(item) == true)
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// Значение явл-ся валидным если есть спец.символы
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool SymbContainsValidate(string value)
        {
            foreach (var item in value)
            {
                if (item == '^')
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Значение явл-ся валидным если есть символ '@'
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool EmailValidate(string value)
        {
            foreach (var item in value)
            {
                if (item == '@')
                {
                    return true;
                }
            }
            return false;
        }


    }
}
