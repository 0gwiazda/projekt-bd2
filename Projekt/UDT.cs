using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Text.RegularExpressions;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using System.IO;
using System.Runtime.InteropServices;

//pierwsze 1 => wymuszony typ "NULL"

namespace Projekt
{
    [Serializable]
    [SqlUserDefinedType(Format.UserDefined, IsByteOrdered = true, ValidationMethodName = "ValidateAnimal", MaxByteSize = -1)]
    public class Animal : IBinarySerialize, INullable
    {
        private string _family;
        private string _species;
        private int _type;
        private int _danger;
        private bool _endangered;
        private int _gender;
        private int _maturity;
        private int _numOfChildren;
        private bool _isNull;


        public Animal()
        {
            _isNull = false;
        }
        public bool IsNull
        {
            get
            {
                return _isNull;
            }
        }
        public static Animal Null
        {
            get
            {
                Animal an = new Animal();
                an._isNull = true;
                return an;
            }
        }

        public string Family
        {
            get
            {
                return _family;
            }
            set
            {
                string temp = _family;
                _family = value;

                if (!ValidateAnimal())
                {
                    _family = temp;
                    throw new ArgumentException("Invalid Family of animal.");
                }
            }
        }
        public string Species
        {
            get
            {
                return _species;
            }
            set
            {
                string temp = _species;
                _species = value;

                if (!ValidateAnimal())
                {
                    _species = temp;
                    throw new ArgumentException("Invalid Species of animal.");
                }
            }
        }

        public int Type
        {
            get
            {
                return _type;
            }
            set
            {
                int temp = _type;
                _type = value;

                if (!ValidateAnimal())
                {
                    _type = temp;
                    throw new ArgumentException("Invalid Type of animal.");
                }
            }
        }
        public int Gender 
        {
            get => _gender;
            set 
            {
                int temp = _gender;
                _gender = value;

                if(!ValidateAnimal())
                {
                    _gender = temp;
                    throw new ArgumentException("Invalid gender");
                }
            }
        }
        public int Maturity 
        {
            get => _maturity;
            set 
            {
                int temp = _maturity;
                _maturity = value;

                if(!ValidateAnimal())
                {
                    _maturity = temp;
                    throw new ArgumentException("Invalid maturity of animal");
                }
            }
        }
        public int NumOfChildren 
        {
            get => _numOfChildren;
            set 
            {
                int temp = _numOfChildren;
                _numOfChildren = value;

                if(!ValidateAnimal())
                {
                    _numOfChildren = temp;
                    throw new ArgumentException("Invalid number of children of animal");
                }
            }
        }
        public int Danger
        {
            get
            {
                return _danger;
            }
            set
            {
                int temp = _danger;
                _danger = value;

                if (!ValidateAnimal())
                {
                    _danger = temp;
                    throw new ArgumentException("Invalid Danger of animal.");
                }
            }
        }
        public SqlBoolean Endangered
        {
            get
            {
                return _endangered;
            }
            set
            {
                bool temp = _endangered;
                _endangered = value.Value;

                if (!ValidateAnimal())
                {
                    _endangered = temp;
                    throw new ArgumentException("Invalid Endangered Value.");
                }
            }
        }
        public string decodeType()
        {
            string str_type = "";

            switch (_type)
            {
                case 0:
                    {
                        str_type = "Spider"; break;
                    }
                case 1:
                    {
                        str_type = "Scorpion"; break;
                    }
                case 2:
                    {
                        str_type = "Solifugae"; break;
                    }
                case 3:
                    {
                        str_type = "Amblypygid"; break;
                    }
                case 4:
                    {
                        str_type = "Uropygid"; break;
                    }
                case 5:
                    {
                        str_type = "Tortoise"; break;
                    }
                case 6:
                    {
                        str_type = "Lizard"; break;
                    }
                case 7:
                    {
                        str_type = "Snake"; break;
                    }
            }

            return str_type;
        }
        public string decodeDanger()
        {
            string dan_lvl;

            if (_danger <= 3)
            {
                dan_lvl = "Safe";
            }
            else if (_danger > 3 && _danger <= 6)
            {
                dan_lvl = "Medium";
            }
            else if (_danger > 6 && _danger <= 9)
            {
                dan_lvl = "Dangerous";
            }
            else
            {
                dan_lvl = "Deadly";
            }

            return dan_lvl;
        }
        public string decodeGender()
        {
            string str_gen = "";

            switch(_gender)
            {
                case 0: 
                    {
                        str_gen = "NS";  
                        break;
                    }
                case 1:
                    {
                        str_gen = "Male";
                        break;
                    }
                case 2:
                    {
                        str_gen = "Female";
                        break;
                    }
            }

            return str_gen;
        }
        public string decodeMaturity()
        {
            string str_mat = "";

            switch(_maturity)
            {
                case 0:
                    {
                        str_mat = "Hatchling";
                        break;
                    }
                case 1:
                    {
                        str_mat = "Juvenile";
                        break;
                    }
                case 2:
                    {
                        str_mat = "Subadult";
                        break;
                    }
                case 3:
                    {
                        str_mat = "Adult";
                        break;
                    }
            }

            return str_mat;
        }

        public override string ToString()
        {
            if (IsNull)
            {
                return "NULL";
            }
            else
            {
                return _family + " " + _species + ", " + decodeType() + ", " + decodeGender() + ", " + decodeMaturity() + ((_gender == 2 && _numOfChildren != 0) ? ", Number of children: " + _numOfChildren : "") + ", Danger: " + decodeDanger() + ", " + ((_endangered) ? "Endangered" : "Not Endangered");
            }
        }

        [SqlMethod(OnNullCall = false)]
        public static Animal Parse(SqlString str)
        { 
            if (str == "")
                return Null;

            string[] data = str.Value.Split(',');

            if (data.Length != 8)
            {
                throw new ArgumentOutOfRangeException("Invalid number of arguments");
            }

            Animal an = new Animal();

            an._family = (string)(data[0]);
            an._species = (string)(data[1]);
            an._type = Int32.Parse(data[2]);
            an._gender = Int32.Parse(data[3]);
            an._maturity = Int32.Parse(data[4]);
            an._numOfChildren = Int32.Parse(data[5]);
            an._danger = Int32.Parse(data[6]);
            an._endangered = Boolean.Parse(data[7]);

            if (!an.ValidateAnimal())
                throw new ArgumentException("Invalid arguments");

            return an;
        }

        public int Filter(SqlString type, SqlString filter)
        {
            if (IsNull) { return 0; }

            if (type == SqlString.Null)
                throw new ArgumentNullException("ERROR: type cannot be null");

            if(filter == SqlString.Null)
                throw new ArgumentNullException("ERROR: filter cannot be null");

            string str_type = type.Value.ToLower();
            string str_filter = filter.Value.ToLower();
            bool result = false;

            switch(str_type)
            {
                case "family": 
                    { 
                        result = _family.ToLower().Equals(str_filter);
                        break; 
                    }
                case "species": 
                    { 
                        result = _species.Equals(str_filter);
                        break; 
                    }
                case "type": 
                    {
                        result = _type == Int32.Parse(str_filter);
                        break; 
                    }
                case "gender": 
                    { 
                        result = _gender == Int32.Parse(str_filter);
                        break; 
                    }
                case "maturity": 
                    { 
                        result = _maturity == Int32.Parse(str_filter);   
                        break; 
                    }
                case "numofchildren":
                    {
                        result = _numOfChildren == Int32.Parse(str_filter);
                        break;
                    }
                case "danger":
                    { 
                        result = decodeDanger().ToLower().Equals(str_filter);
                        break; 
                    }
                case "endangered": 
                    { 
                        result = _endangered == Boolean.Parse(str_filter);   
                        break; 
                    }
            }

            return (result) ? 1 : 0;
        }
        private int countDistance(int check)
        {
            Animal dist = new Animal() { _danger = check };

            if(dist.decodeDanger().Equals(decodeDanger()))
            {
                return 0;
            }
            else 
            {
                string[] dangers = { "Safe", "Medium", "Dangerous", "Deadly" };

                int dist1 = Array.IndexOf(dangers, dist.decodeDanger());
                int dist2 = Array.IndexOf(dangers, decodeDanger());

                return (dist1 > dist2) ? dist2 - dist1 : 1;
            }
        }
        public int checkDanger(int toCheck)
        {
            if(_danger > toCheck)
            {
                return 1;
            }
            else if(toCheck == _danger)
            {
                return 0;
            }
            else 
            {
                return countDistance(toCheck);
            }
        }

        private bool ValidateAnimal()
        {
            if ((_danger < 0 || _danger > 10) || (_type < 0 || _type > 7))
            {
                return false;
            }
            else if ((_gender < 0 || _gender > 2) || (_maturity < 0 || _maturity > 3))
            {
                return false;
            }
            else if ((_gender != 2 && _numOfChildren != 0) || (_gender == 2 && _maturity != 3 && _numOfChildren != 0))
            {
                return false;
            }
            else if (_family.Any(char.IsDigit) || _species.Any(char.IsDigit))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public void Read(BinaryReader r)
        {
            string temp = r.ReadString();
            var fam_species = temp.Split('.');

            _family = fam_species[0];
            _species = fam_species[1];

            _type = r.ReadInt32();
            _gender = r.ReadInt32();
            _maturity = r.ReadInt32();
            _numOfChildren = r.ReadInt32();
            _danger = r.ReadInt32();
            _endangered = r.ReadBoolean();
        }
        public void Write(BinaryWriter w)
        {
            string toWrite = _family + "." + _species;
            w.Write(toWrite);
            w.Write(_type);
            w.Write(_gender);
            w.Write(_maturity);
            w.Write(_numOfChildren);
            w.Write(_danger);
            w.Write(_endangered);
        }
    };

    [Serializable]
    [SqlUserDefinedType(Format.UserDefined, IsByteOrdered = true, ValidationMethodName = "ValidateAddress", MaxByteSize = -1)]
    public class Address : IBinarySerialize, INullable 
    {
        private string _addr_line1;
        private string _addr_line2;
        private string _code;
        private string _city;
        private bool _isNull;


        public Address()
        {
            _isNull = false;
        }
        public static Address Null 
        {
            get 
            {
                Address addr = new Address() { _isNull = true };
                return addr;
            }
        }
        public bool IsNull 
        {
            get => _isNull;
        }
        public string Address_Line1
        {
            get => _addr_line1;

            set 
            {
                string temp = _addr_line1;
                _addr_line1 = value;

                if(!ValidateAddress())
                {
                    _addr_line1 = temp;
                    throw new ArgumentException("Invalid address line 1");
                }
            }
        }
        public string Address_Line2
        {
            get => _addr_line2;

            set
            {
                string temp = _addr_line2;
                _addr_line2 = value;

                if (!ValidateAddress())
                {
                    _addr_line2 = temp;
                    throw new ArgumentException("Invalid address line 2");
                }
            }
        }
        public string Code 
        {
            get => _code;

            set 
            {
                string temp = _code;
                _code = value;

                if(!ValidateAddress())
                {
                    _code = temp;
                    throw new ArgumentException("Invalid code");
                }
            }
        }
        public string City 
        {
            get => _city;

            set 
            {
                string temp = _city;
                _city = value;

                if(!ValidateAddress())
                {
                    _city = temp;
                    throw new ArgumentException("Invalid city");
                }
            }
        }
        public override string ToString()
        {
            if (IsNull)
            {
                return "NULL";
            }
            else
            {
                return "" + _addr_line1 + ", " + _addr_line2 + ", " + _code + " " + _city;
            }
        }

        [SqlMethod(OnNullCall = false)]
        public static Address Parse(SqlString toParse)
        {
            if (toParse == "")
                return Null;

            string[] data = toParse.Value.Split(',');

            if (data.Length != 4) 
                throw new ArgumentException("Invalid number of arguments");

            Address addr = new Address() { _isNull = false };

            addr._addr_line1 = data[0];
            addr._addr_line2 = data[1];
            addr._code = data[2];
            addr._city = data[3];

            if(!addr.ValidateAddress())
            {
                throw new ArgumentException("Invalid arguments.");
            }

            return addr;
        }

        public int Filter(SqlString type, SqlString filter)
        {
            if(IsNull) { return 0; }

            if(type  == SqlString.Null)
                throw new ArgumentNullException("ERROR: type cannot be null");

            if(filter == SqlString.Null)
                throw new ArgumentNullException("ERROR: filter cannot be null");

            string str_type = type.Value.ToLower();
            string str_filter = filter.Value.ToLower();

            bool result = false;

            switch(str_type)
            {
                case "addr_line1": 
                    {
                        result = _addr_line1.ToLower().Equals(str_filter);
                        break; 
                    }
                case "addr_line2":
                    {
                        result = _addr_line2.ToLower().Equals(str_filter);
                        break;
                    }
                case "code":
                    {
                        result = _code.Equals(str_filter);
                        break;
                    }
                case "city":
                    {
                        result = _city.ToLower().Equals(str_filter);
                        break;
                    }
            }

            return (result) ? 1 : 0;
        }

        public bool ValidateAddress()
        {
            if (!_code.Contains("-") || !_addr_line1.Any(char.IsDigit) || _city.Any(char.IsDigit))
            {
                return false;
            }
            else
            {
                return true;
            } 
        }

        public void Read(BinaryReader r)
        {
            _addr_line1 = r.ReadString();
            _addr_line2 = r.ReadString();
            _code = r.ReadString();
            _city = r.ReadString();
        }
        public void Write(BinaryWriter w)
        {
            w.Write(_addr_line1);
            w.Write(_addr_line2);
            w.Write(_code);
            w.Write(_city);
        }
    }
    
    [Serializable]
    [SqlUserDefinedType(Format.UserDefined, IsByteOrdered = true, MaxByteSize = -1, ValidationMethodName = "ValidateEmail")]
    public class EmailAddress : IBinarySerialize, INullable
    {
        private string _email;
        private bool _isNull;

        public EmailAddress()
        {
            _isNull = false;
        }
        public EmailAddress(string email)
        {
            Email = email;
            _isNull = false;
        }
        public bool IsNull
        {
            get
            {
                return _isNull;
            }
        }

        public static EmailAddress Null
        {
            get
            {
                EmailAddress em = new EmailAddress() { _isNull = true };

                return em;
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                string temp = _email;
                _email = value;

                if (!ValidateEmail())
                {
                    _email = temp;
                    throw new ArgumentException("Invalid email");
                }
            }
        }
        public override string ToString()
        {
            if (IsNull)
            {
                return "NULL";
            }
            else
            {
                return _email;
            }
        }

        [SqlMethod(OnNullCall = false)]
        public static EmailAddress Parse(SqlString toParse)
        {
            if (toParse == "")
                return Null;

            string data = toParse.Value;
            
            EmailAddress em = new EmailAddress();
            em._email = data;

            if (!em.ValidateEmail())
                throw new ArgumentException("Invalid arguments");

            return em;
        }

        public int Filter(SqlString type, SqlString filter)
        {
            if(IsNull) { return 0; }

            if(type == SqlString.Null)
                throw new ArgumentNullException("ERROR: type cannot be null");

            if (filter == SqlString.Null)
                throw new ArgumentNullException("ERROR: filter cannot be null");

            string str_type = type.Value.ToLower();
            string str_filter = filter.Value.ToLower();

            bool result = false;

            if (str_type.Equals("email"))
            {
                result = _email.Equals(str_filter);
            }
            else if (str_type.Equals("domain"))
            {
                result = _email.Split('@')[1].Equals(str_filter);
            }
            
            return (result) ? 1 : 0;
        }
        public bool ValidateEmail()
        {
            if (!_email.Contains("@"))
            {
                return false;
            }
            else
            {
                string[] parts = _email.Split('@');

                if (!parts[1].Contains("."))
                {
                    return false;
                }

                return true;
            }

        }

        public void Read(BinaryReader r)
        {
            _email = r.ReadString();
        }

        public void Write(BinaryWriter w)
        {
            w.Write(_email);
        }
    }
    [Serializable]
    [SqlUserDefinedType(Format.UserDefined, IsByteOrdered = true, MaxByteSize = -1, ValidationMethodName = "ValidateDocument")]
    public class DangerDocument : IBinarySerialize, INullable
    {
        private Animal _pet;
        private string _owner;
        private string _date;
        private int[] _documentNumber;
        private bool _isNull;

        public DangerDocument()
        {
            _isNull = false;
        }
        public DangerDocument(string owner, string animal, string date)
        {
            _pet = Animal.Parse(animal);
            _owner = owner;
            _date = date;
            _isNull = false;

            createDocumentNumber();
        }
        public static DangerDocument Null 
        {
            get 
            {
                DangerDocument dan = new DangerDocument() { _isNull = true };
                return dan;
            }
        }
        public bool IsNull
        {
            get { return _isNull; }
        }

        public Animal Pet
        {
            get { return _pet; }
        }
        public string Owner
        {
            get { return _owner; }
        }
        public string Date
        {
            get { return _date; }
            set
            {
                string _temp = _date;
                _date = value;
                createDocumentNumber();

                if (!ValidateDocument())
                {
                    _date = _temp;
                    throw new ArgumentException("Invalid date.");
                }
            }
        }
        public int[] DocumentNumber
        {
            get { return _documentNumber; }
        }
        [SqlMethod(OnNullCall = false)]
        public static DangerDocument Parse(SqlString str)
        {
            if (str == "")
                return Null;

            string[] data = str.Value.Split(';');

            if (data.Length != 3)
                throw new ArgumentException("Invalid number of arguments");

            DangerDocument dd = new DangerDocument(data[0], data[1], data[2]);

            if (!dd.ValidateDocument())
            {
                throw new ArgumentException("Invalid arguments");
            }

            return dd;
        }
        public override string ToString()
        {
            if (IsNull)
            {
                return "NULL";
            }
            else
            {
                string str = "";
                foreach (int i in _documentNumber)
                {
                    str += "" + i;
                }

                return str;
            }
        }

        public int Filter(SqlString type, SqlString filter)
        {
            if (IsNull) { return 0; }

            if (type == SqlString.Null)
                throw new ArgumentNullException("ERROR: type cannot be null");

            if (filter == SqlString.Null)
                throw new ArgumentNullException("ERROR: filter cannot be null");

            string str_type = type.Value.ToLower();
            string str_filter = filter.Value.ToLower();

            if (str_type.Equals("owner"))
            {
                return (_owner.ToLower().Equals(str_filter)) ? 1 : 0;
            }
            else if (str_type.Equals("date"))
            {
                return (_date.Equals(str_filter)) ? 1 : 0;
            }
            else if (str_type.Contains("animal"))
            {
                return _pet.Filter(str_type.Split('.')[1], str_filter);
            }
            else
            {
                return 0;
            }
        }

        private int countCheckSum(List<int> number)
        {
            int check_sum = 0;
            int[] wages = new int[4] { 2, 3, 1, 8 };

            for (int i = 0; i < number.Count; i++)
            {
                check_sum += number[i] * wages[i % 4];
            }

            return check_sum;
        }
        public void createDocumentNumber()
        {
            string[] owner = _owner.Split(' ');
            string[] animal = {_pet.Family, _pet.Species };

            List<int> number = new List<int>();

            foreach (string s in owner)
            {
                string sl = s.ToLower();
                for (int i = 0; i < 3; i++)
                {
                    number.Add(((int)(sl[i] - 'a')) / 10);
                    number.Add(((int)(sl[i] - 'a')) % 10);
                }
            }
            foreach (string s in animal)
            {
                string sl = s.ToLower();
                for (int i = 0; i < 3; i++)
                {
                    number.Add(((int)(sl[i] - 'a')) / 10);
                    number.Add(((int)(sl[i] - 'a')) % 10);
                }
            }

            number.Add((_pet.Danger / 10));
            number.Add((_pet.Danger % 10));

            foreach (char s in _date)
            {
                if (s >= '0' && s <= '9')
                {
                    number.Add((int)(s - '0'));
                }
            }

            int check_sum = countCheckSum(number);

            if (check_sum % 10 != 0)
            {
                check_sum = 10 - check_sum % 10;
            }
            else
            {
                check_sum = 0;
            }

            number.Add(check_sum);

            _documentNumber = new int[number.Count];
            number.CopyTo(_documentNumber);
        }

        public bool ValidateDocument()
        {
            if (_documentNumber.Length < 0)
            {
                return false;
            }
            else if (_owner.Any(char.IsDigit))
            {
                return false;
            }
            else
            {
                if (countCheckSum(_documentNumber.ToList<int>()) % 10 != 0)
                {
                    return false;
                }
                if (_documentNumber[24] * 10 + _documentNumber[25] < 0 || _documentNumber[24] * 10 + _documentNumber[25] > 10)
                {
                    return false;
                }

                return true;
            }
        }

        public void Read(BinaryReader r)
        {
            _owner = r.ReadString();
            _pet = new Animal();
            _pet.Read(r);

            _date = r.ReadString();

            int len = r.ReadInt32();

            _documentNumber = new int[len];

            for (int i = 0; i < len; i++)
            {
                _documentNumber[i] = r.ReadInt32();
            }
        }
        public void Write(BinaryWriter w)
        {
            w.Write(_owner);
            _pet.Write(w);

            w.Write(_date);

            w.Write(_documentNumber.Length);

            foreach (int i in _documentNumber)
            {
                w.Write(i);
            }
        }
    }

    [Serializable]
    [SqlUserDefinedType(Format.UserDefined, IsByteOrdered = true, MaxByteSize = -1, ValidationMethodName = "ValidateDocument")]
    public class CITESDocument : INullable, IBinarySerialize
    {
        private Animal _pet;
        private string _owner;
        private string _date;
        private int[] _documentNumber;
        private bool _isNull;


        public CITESDocument() 
        { 
            _isNull = false;
        }
        public CITESDocument(string animal_data, string owner, string date)
        {
            _pet = Animal.Parse(animal_data);
            
            //_maturity = animal[1];
            //_gender = animal[2];

            _owner = owner;
            _date = date;

            createDocumentNumber();
        }
        public static CITESDocument Null 
        {
            get 
            {
                CITESDocument cit = new CITESDocument() { _isNull = true };
                return cit;
            }
        }
        public bool IsNull 
        {
            get { return _isNull; }
        }
        public Animal Pet
        {
            get { return _pet; }
        }
        public string Owner
        {
            get { return _owner; }
        }
        public string Date
        {
            get { return _date; }
            set
            {
                string _temp = _date;
                _date = value;
                createDocumentNumber();

                if (!ValidateDocument())
                {
                    _date = _temp;
                    throw new ArgumentException("Invalid date.");
                }
            }
        }
        public int[] DocumentNumber
        {
            get { return _documentNumber; }
        }
        private int countCheckSum(List<int> number)
        {
            int check_sum = 0;
            int[] wages = new int[4] { 2, 3, 5, 1 };

            for (int i = 0; i < number.Count; i++)
            {
                check_sum += number[i] * wages[i % 4];
            }

            return check_sum;
        }
        public void createDocumentNumber()
        {
            string[] owner = _owner.Split(' ');
            string[] animal = { _pet.Family, _pet.Species };

            List<int> number = new List<int>();

            foreach (string s in owner)
            {
                string sl = s.ToLower();
                for (int i = 0; i < 3; i++)
                {
                    number.Add(((int)(sl[i] - 'a')) / 10);
                    number.Add(((int)(sl[i] - 'a')) % 10);
                }
            }
            foreach (string s in animal)
            {
                string sl = s.ToLower();
                for (int i = 0; i < 3; i++)
                {
                    number.Add(((int)(sl[i] - 'a')) / 10);
                    number.Add(((int)(sl[i] - 'a')) % 10);
                }
            }

            number.Add(_pet.Maturity);

            number.Add(_pet.Gender);

            number.Add(_pet.NumOfChildren);

            foreach (char s in _date)
            {
                if (s >= '0' && s <= '9')
                {
                    number.Add((int)(s - '0'));
                }
            }

            int check_sum = countCheckSum(number);

            if (check_sum % 10 != 0)
            {
                check_sum = 10 - check_sum % 10;
            }
            else
            {
                check_sum = 0;
            }

            number.Add(check_sum);

            _documentNumber = new int[number.Count];
            number.CopyTo(_documentNumber);
        }
        public override string ToString()
        {
            if (IsNull)
            {
                return "NULL";
            }
            else
            {
                string str = "";
                foreach (int i in _documentNumber)
                {
                    str += "" + i;
                }

                return str;
            }
        }

        [SqlMethod(OnNullCall = false)]
        public static CITESDocument Parse(SqlString str)
        {
            if (str == "")
                return Null;
            
            string[] data = str.Value.Split(';');

            if (data.Length != 3)
                throw new ArgumentException("Invalid number of arguments.");

            string owner = data[0];
            string animal_data = data[1];
            string date = data[2];

            CITESDocument cd = new CITESDocument(animal_data, owner, date);

            cd.createDocumentNumber();

            if (!cd.ValidateDocument())
            {
                throw new ArgumentException("Invalid arguments");
            }

            return cd;
            
        }

        public int Filter(SqlString type, SqlString filter)
        {
            if (IsNull) { return 0; }

            if (type == SqlString.Null)
                throw new ArgumentNullException("ERROR: type cannot be null");

            if (filter == SqlString.Null)
                throw new ArgumentNullException("ERROR: filter cannot be null");

            string str_type = type.Value.ToLower();
            string str_filter = filter.Value.ToLower();

            if (str_type.Equals("owner"))
            {
                return (_owner.ToLower().Equals(str_filter)) ? 1 : 0;
            }
            else if (str_type.Equals("date"))
            {
                return (_date.Equals(str_filter)) ? 1 : 0;
            }
            else if (str_type.Contains("animal"))
            {
                return _pet.Filter(str_type.Split('.')[1], str_filter);
            }
            else
            {
                return 0;
            }
        }

        public bool ValidateDocument() 
        {
            if (_documentNumber.Length < 25)
            {
                return false;
            }
            else if(_owner.Any(char.IsDigit))
            {
                return false;
            }
            else 
            {
                if (countCheckSum(_documentNumber.ToList<int>()) % 10 != 0)
                {
                    return false;
                }
                if(!_pet.Endangered)
                {
                    return false;
                }
                return true;
            }
        }
        public void Read(BinaryReader r)
        {
            _pet = new Animal();
            _pet.Read(r);
            _owner = r.ReadString();

            int len = r.ReadInt32();

            _documentNumber = new int[len];

            for (int i = 0; i < len; i++)
            {
                _documentNumber[i] = r.ReadInt32();
            }
        }
        public void Write(BinaryWriter w)
        {
            _pet.Write(w);
            w.Write(_owner);

            int len = _documentNumber.Length;

            w.Write(len);
            
            foreach(int i in _documentNumber)
                w.Write(i);

        }
    }
    [Serializable]
    [SqlUserDefinedType(Format.UserDefined, IsByteOrdered = true, MaxByteSize = -1, ValidationMethodName = "ValidateEnclosure")]
    public class Enclosure : INullable, IBinarySerialize
    {
        private string _type;
        private double _length;
        private double _width;
        private double _height;
        private bool _decorated;
        private string _enviroment;
        private bool _isNull;


        public Enclosure()
        {
            _isNull = false;
        }
        public static Enclosure Null
        {
            get
            {
                Enclosure en = new Enclosure() { _isNull = true };
                return en;
            }
        }
        public bool IsNull
        {
            get => _isNull;
        }

        public string Type 
        {
            get => _type;

            set 
            {
                string temp = _type;
                _type = value;

                if (!ValidateEnclosure())
                {
                    _type = temp;
                    throw new ArgumentException("Invalid type");
                }
            }
        }

        public double Length 
        {
            get => _length;

            set 
            {
                double temp = _length;
                _length = value;

                if(!ValidateEnclosure())
                {
                    _length = temp;
                    throw new ArgumentException("Invalid length");
                }
            }
        } 

        public double Width 
        {
            get => _width;

            set 
            {
                double temp = _width;
                _width = value;

                if(!ValidateEnclosure())
                {
                    _width = temp;
                    throw new ArgumentException("Invalid width");
                }
            }
        }

        public double Height 
        {
            get => _height;

            set 
            {
                double temp = _height;
                _height = value;

                if (!ValidateEnclosure())
                {
                    _height = temp;
                    throw new ArgumentException("Invalid height");
                }
            }
        }

        public bool Decorated 
        {
            get => _decorated;

            set 
            {
                bool temp = _decorated;
                _decorated = value;

                if(!ValidateEnclosure())
                {
                    _decorated = temp;
                    throw new ArgumentException("Invalid decorated");
                }
            }
        }

        public string Enviroment 
        {
            get => _enviroment;

            set
            {
                string temp = _enviroment;
                _enviroment = value;

                if(!ValidateEnclosure())
                {
                    _enviroment = temp;
                    throw new ArgumentException("Invalid enviroment");
                }
            }
        }

        public override string ToString()
        {
            if (IsNull)
            {
                return "NULL";
            }
            else
            {
                string str = _type + " " + _length + "cm x " + _width + "cm x " + _height + "cm ";
                str += (_decorated) ? _enviroment : "";

                return str;
            }
        }

        [SqlMethod(OnNullCall = false)]
        public static Enclosure Parse(SqlString toParse)
        {
            if (toParse == "")
                return Null;

            string [] data = toParse.Value.Split(',');


            if(data.Length != 4)
            {
                throw new ArgumentException("Invalid number of arguments");
            }

            string[] size = data[1].Split('x');

            Enclosure en = new Enclosure();

            en._type = data[0];
            en._length = Double.Parse(size[0]);
            en._width = Double.Parse(size[1]);
            en._height = Double.Parse(size[2]);
            en._decorated = Boolean.Parse(data[2]);

            en._enviroment = (en._decorated) ? data[3] : "";

            if (!en.ValidateEnclosure())
            {
                throw new ArgumentException("Invalid arguments");
            }

            return en;
        }

        public int Filter(SqlString type, SqlString filter) 
        {
            if(IsNull) { return 0; }

            if (type == SqlString.Null)
                throw new ArgumentNullException("ERROR: type cannot be null");

            if (filter == SqlString.Null)
                throw new ArgumentNullException("ERROR: filter cannot be null");

            string str_type = type.Value.ToLower();
            string str_filter = filter.Value.ToLower();

            bool result = false;

            switch (str_type)
            {
                case "type":
                    {
                        result = _type.Equals(str_filter);
                        break; 
                    }
                case "length":
                    {
                        result = _length == Double.Parse(str_filter);
                        break; 
                    }
                case "width":
                    { 
                        result = _width == Double.Parse(str_filter);
                        break; 
                    }
                case "height":
                    {
                        result = _height == Double.Parse(str_filter);
                        break; 
                    }
                case "decorated":
                    {
                        result = _decorated == Boolean.Parse(str_filter);
                        break; 
                    }
                case "enviroment":
                    {
                        if(_decorated)
                            result = _enviroment.Equals(str_filter);
                        else 
                            result = false;

                        break; 
                    }
            }

            return (result) ? 1 : 0;
        }

        public bool ValidateEnclosure() 
        {
            if (!_type.Equals("terrarium") && !_type.Equals("faunarium") && !_type.Equals("aquarium"))
            {
                return false;
            }
            else if (_length < 0 || _width < 0 || _height < 0)
            {
                return false;
            }
            else if (_decorated && _enviroment == "")
            {
                return false;
            }
            else 
            {
                return true;
            }
        }

        public void Read(BinaryReader r)
        {
            _type = r.ReadString();
            _length = r.ReadDouble();
            _width = r.ReadDouble();
            _height = r.ReadDouble();
            _decorated = r.ReadBoolean();
            _enviroment = (_decorated) ? r.ReadString() : ""; 
        }
        public void Write(BinaryWriter w)
        {
            w.Write(_type);
            w.Write(_length);
            w.Write(_width);
            w.Write(_height);
            w.Write(_decorated);

            if (_decorated)
                w.Write(_enviroment);
        }

    }
}