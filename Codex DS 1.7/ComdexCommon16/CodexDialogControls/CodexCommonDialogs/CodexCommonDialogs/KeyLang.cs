using System;


namespace ILG.Codex.CodexR4.KeyBoard
{
    public enum KeyLayout { English, GeorgianLat, GeorgianRus, Russian, None }

    public class Layout
    {
        public static bool IsActive; 
        static public KeyLayout KeySet;
        static public char[] C;

        static public char[] U;


        static Layout()
        {
            C = new char[0XFF00];
            // Set English
            KeySet = KeyLayout.English;
            for (int i = 0; i < 0XFF00; i++)
                C[i] = Convert.ToChar(i);

            U = new char[0XFF00];
            // Set English
            KeySet = KeyLayout.English;
            for (int i = 0; i < 0XFF00; i++)
                U[i] = Convert.ToChar(i);

            IsActive = true;

        }


        static public void SetEnglish()
        {
            KeyBoard.Layout.SetEnglish8();
            KeyBoard.Layout.SetEnglishU();
            IsActive = true;
        }

        static public void SetGeorgianLat()
        {
            KeyBoard.Layout.SetGeorgianLat8();
            KeyBoard.Layout.SetGeorgianLatU();
            IsActive = true;
        }

        static public void SetGeorgianRus()
        {
            KeyBoard.Layout.SetGeorgianRus8();
            KeyBoard.Layout.SetGeorgianRusU();
            IsActive = true;
        }

        static public void SetRussian()
        {
            KeyBoard.Layout.SetRussian8();
            KeyBoard.Layout.SetRussianU();
            IsActive = true;
        }

        static public void SetOff()
        {
            IsActive = false;
        }


        #region 8 Bit Filter
        static private void SetEnglish8()
        {
            //C = new char[256];
            KeySet = KeyLayout.English;
            for (int i = 0; i <= 255; i++)
                C[i] = Convert.ToChar(i);

        }

        static private void SetGeorgianLat8()
        {
            KeySet = KeyLayout.GeorgianLat;
            //C = new char[256];

            for (int i = 0; i <= 255; i++)
                C[i] = Convert.ToChar(i);

            C[Convert.ToInt16('q')] = 'Ø'; C[Convert.ToInt16('w')] = 'ß'; C[Convert.ToInt16('e')] = 'Ä';
            C[Convert.ToInt16('r')] = 'Ò'; C[Convert.ToInt16('t')] = 'Ô'; C[Convert.ToInt16('y')] = 'Ú';
            C[Convert.ToInt16('u')] = 'Ö'; C[Convert.ToInt16('i')] = 'É'; C[Convert.ToInt16('o')] = 'Ï';
            C[Convert.ToInt16('p')] = 'Ð'; C[Convert.ToInt16('a')] = 'À'; C[Convert.ToInt16('s')] = 'Ó';
            C[Convert.ToInt16('d')] = 'Ã'; C[Convert.ToInt16('f')] = '×'; C[Convert.ToInt16('g')] = 'Â';
            C[Convert.ToInt16('h')] = 'ä'; C[Convert.ToInt16('j')] = 'ã'; C[Convert.ToInt16('k')] = 'Ê';
            C[Convert.ToInt16('l')] = 'Ë'; C[Convert.ToInt16('z')] = 'Æ'; C[Convert.ToInt16('x')] = 'á';
            C[Convert.ToInt16('c')] = 'Ý'; C[Convert.ToInt16('v')] = 'Å'; C[Convert.ToInt16('b')] = 'Á';
            C[Convert.ToInt16('n')] = 'Í'; C[Convert.ToInt16('m')] = 'Ì'; C[Convert.ToInt16('W')] = 'à';
            C[Convert.ToInt16('R')] = 'Ù'; C[Convert.ToInt16('T')] = 'È'; C[Convert.ToInt16('C')] = 'Ü';
            C[Convert.ToInt16('J')] = 'Ñ'; C[Convert.ToInt16('S')] = 'Û'; C[Convert.ToInt16('Z')] = 'Þ';

        }

        static private void SetGeorgianRus8()
        {
            KeySet = KeyLayout.GeorgianRus;
            //C = new char[256];

            for (int i = 0; i <= 255; i++)
                C[i] = Convert.ToChar(i);


            C[Convert.ToInt16('q')] = 'Ù'; C[Convert.ToInt16('w')] = 'Ý'; C[Convert.ToInt16('e')] = 'Ö';
            C[Convert.ToInt16('r')] = 'Ê'; C[Convert.ToInt16('t')] = 'Ä'; C[Convert.ToInt16('y')] = 'Í';
            C[Convert.ToInt16('u')] = 'Â'; C[Convert.ToInt16('i')] = 'Û'; C[Convert.ToInt16('o')] = 'ß';
            C[Convert.ToInt16('p')] = 'Æ'; C[Convert.ToInt16('a')] = '×'; C[Convert.ToInt16('s')] = 'È';
            C[Convert.ToInt16('d')] = 'Å'; C[Convert.ToInt16('f')] = 'À'; C[Convert.ToInt16('g')] = 'Ð';
            C[Convert.ToInt16('h')] = 'Ò'; C[Convert.ToInt16('j')] = 'Ï'; C[Convert.ToInt16('k')] = 'Ë';
            C[Convert.ToInt16('l')] = 'Ã'; C[Convert.ToInt16('z')] = 'à'; C[Convert.ToInt16('x')] = 'Ü';
            C[Convert.ToInt16('c')] = 'Ó'; C[Convert.ToInt16('v')] = 'Ì'; C[Convert.ToInt16('b')] = 'É';
            C[Convert.ToInt16('n')] = 'Ô'; C[Convert.ToInt16('m')] = 'Ø'; C[Convert.ToInt16(',')] = 'Á';
            C[Convert.ToInt16('.')] = 'Ú'; C[Convert.ToInt16(';')] = 'Ñ'; C[Convert.ToInt16('\'')] = 'Þ';
            C[Convert.ToInt16('[')] = 'á'; C[Convert.ToInt16(']')] = 'ã'; C[Convert.ToInt16('$')] = ';';
            C[Convert.ToInt16('^')] = ':'; C[Convert.ToInt16('`')] = '~'; C[Convert.ToInt16('~')] = 'ä';
            C[Convert.ToInt16('&')] = '?';

        }

        static private void SetRussian8()
        {
            KeySet = KeyLayout.Russian;
            //C = new char[256];

            for (int i = 0; i <= 255; i++)
                C[i] = Convert.ToChar(i);


            C[Convert.ToInt16('q')] = 'é';
            C[Convert.ToInt16('w')] = 'ö';
            C[Convert.ToInt16('e')] = 'ó';
            C[Convert.ToInt16('r')] = 'ê';
            C[Convert.ToInt16('t')] = 'å';
            C[Convert.ToInt16('y')] = 'í';
            C[Convert.ToInt16('u')] = 'ã';
            C[Convert.ToInt16('i')] = 'ø';
            C[Convert.ToInt16('o')] = 'ù';
            C[Convert.ToInt16('p')] = 'ç';
            C[Convert.ToInt16('[')] = 'õ';
            C[Convert.ToInt16(']')] = 'ú';
            C[Convert.ToInt16('\\')] = '\\';

            C[Convert.ToInt16('a')] = 'ô';
            C[Convert.ToInt16('s')] = 'û';
            C[Convert.ToInt16('d')] = 'â';
            C[Convert.ToInt16('f')] = 'à';
            C[Convert.ToInt16('g')] = 'ï';
            C[Convert.ToInt16('h')] = 'ð';
            C[Convert.ToInt16('j')] = 'î';
            C[Convert.ToInt16('k')] = 'ë';
            C[Convert.ToInt16('l')] = 'ä';
            C[Convert.ToInt16(';')] = 'æ';
            C[Convert.ToInt16('\'')] = 'ý';

            C[Convert.ToInt16('z')] = 'ÿ';
            C[Convert.ToInt16('x')] = '÷';
            C[Convert.ToInt16('c')] = 'ñ';
            C[Convert.ToInt16('v')] = 'ì';
            C[Convert.ToInt16('b')] = 'è';
            C[Convert.ToInt16('n')] = 'ò';
            C[Convert.ToInt16('m')] = 'ü';
            C[Convert.ToInt16(',')] = 'á';
            C[Convert.ToInt16('.')] = 'þ';
            C[Convert.ToInt16('/')] = '.';

            C[Convert.ToInt16('`')] = '¸';

            C[Convert.ToInt16('~')] = '¨';
            C[Convert.ToInt16('!')] = '!';
            C[Convert.ToInt16('@')] = '"';
            C[Convert.ToInt16('#')] = '¹';
            C[Convert.ToInt16('$')] = ';';
            C[Convert.ToInt16('%')] = '%';
            C[Convert.ToInt16('^')] = ':';
            C[Convert.ToInt16('&')] = '?';
            C[Convert.ToInt16('*')] = '*';
            C[Convert.ToInt16('(')] = '(';
            C[Convert.ToInt16(')')] = ')';
            C[Convert.ToInt16('_')] = '_';
            C[Convert.ToInt16('+')] = '+';

            C[Convert.ToInt16('Q')] = 'É';
            C[Convert.ToInt16('W')] = 'Ö';
            C[Convert.ToInt16('E')] = 'Ó';
            C[Convert.ToInt16('R')] = 'Ê';
            C[Convert.ToInt16('T')] = 'Å';
            C[Convert.ToInt16('Y')] = 'Í';
            C[Convert.ToInt16('U')] = 'Ã';
            C[Convert.ToInt16('I')] = 'Ø';
            C[Convert.ToInt16('O')] = 'Ù';
            C[Convert.ToInt16('P')] = 'Ç';
            C[Convert.ToInt16('{')] = 'Õ';
            C[Convert.ToInt16('}')] = 'Ú';
            C[Convert.ToInt16('|')] = '/';

            C[Convert.ToInt16('A')] = 'Ô';
            C[Convert.ToInt16('S')] = 'Û';
            C[Convert.ToInt16('D')] = 'Â';
            C[Convert.ToInt16('F')] = 'À';
            C[Convert.ToInt16('G')] = 'Ï';
            C[Convert.ToInt16('H')] = 'Ð';
            C[Convert.ToInt16('J')] = 'Î';
            C[Convert.ToInt16('K')] = 'Ë';
            C[Convert.ToInt16('L')] = 'Ä';
            C[Convert.ToInt16(':')] = 'Æ';
            C[Convert.ToInt16('"')] = 'Ý';

            C[Convert.ToInt16('Z')] = 'ß';
            C[Convert.ToInt16('X')] = '×';
            C[Convert.ToInt16('C')] = 'Ñ';
            C[Convert.ToInt16('V')] = 'Ì';
            C[Convert.ToInt16('B')] = 'È';
            C[Convert.ToInt16('N')] = 'Ò';
            C[Convert.ToInt16('M')] = 'Ü';
            C[Convert.ToInt16('<')] = 'Á';
            C[Convert.ToInt16('>')] = 'Þ';
            C[Convert.ToInt16('?')] = ',';
        }

        #endregion 8 Bit Filter

        #region 16 Bit Filter
        static private void SetEnglishU()
        {
            //C = new char[256];
            KeySet = KeyLayout.English;
            for (int i = 0; i <= 255; i++)
                U[i] = Convert.ToChar(i);

        }
        static private void SetGeorgianLatU()
        {
            KeySet = KeyLayout.GeorgianLat;
            //C = new char[256];

            for (int i = 0; i <= 255; i++)
                U[i] = Convert.ToChar(i);

            U[Convert.ToInt16('q')] = 'ქ'; U[Convert.ToInt16('w')] = 'წ'; U[Convert.ToInt16('e')] = 'ე';
            U[Convert.ToInt16('r')] = 'რ'; U[Convert.ToInt16('t')] = 'ტ'; U[Convert.ToInt16('y')] = 'ყ';
            U[Convert.ToInt16('u')] = 'უ'; U[Convert.ToInt16('i')] = 'ი'; U[Convert.ToInt16('o')] = 'ო';
            U[Convert.ToInt16('p')] = 'პ'; U[Convert.ToInt16('a')] = 'ა'; U[Convert.ToInt16('s')] = 'ს';
            U[Convert.ToInt16('d')] = 'დ'; U[Convert.ToInt16('f')] = 'ფ'; U[Convert.ToInt16('g')] = 'გ';
            U[Convert.ToInt16('h')] = 'ჰ'; U[Convert.ToInt16('j')] = 'ჯ'; U[Convert.ToInt16('k')] = 'კ';
            U[Convert.ToInt16('l')] = 'ლ'; U[Convert.ToInt16('z')] = 'ზ'; U[Convert.ToInt16('x')] = 'ხ';
            U[Convert.ToInt16('c')] = 'ც'; U[Convert.ToInt16('v')] = 'ვ'; U[Convert.ToInt16('b')] = 'ბ';
            U[Convert.ToInt16('n')] = 'ნ'; U[Convert.ToInt16('m')] = 'მ'; U[Convert.ToInt16('W')] = 'ჭ';
            U[Convert.ToInt16('R')] = 'ღ'; U[Convert.ToInt16('T')] = 'თ'; U[Convert.ToInt16('C')] = 'ჩ';
            U[Convert.ToInt16('J')] = 'ჟ'; U[Convert.ToInt16('S')] = 'შ'; U[Convert.ToInt16('Z')] = 'ძ';

        }

        static private void SetGeorgianRusU()
        {
            KeySet = KeyLayout.GeorgianRus;
            //C = new char[256];

            for (int i = 0; i <= 255; i++)
                U[i] = Convert.ToChar(i);


            U[Convert.ToInt16('q')] = 'ღ'; U[Convert.ToInt16('w')] = 'ც'; U[Convert.ToInt16('e')] = 'უ';
            U[Convert.ToInt16('r')] = 'კ'; U[Convert.ToInt16('t')] = 'ე'; U[Convert.ToInt16('y')] = 'ნ';
            U[Convert.ToInt16('u')] = 'გ'; U[Convert.ToInt16('i')] = 'შ'; U[Convert.ToInt16('o')] = 'წ';
            U[Convert.ToInt16('p')] = 'ზ'; U[Convert.ToInt16('a')] = 'ფ'; U[Convert.ToInt16('s')] = 'თ';
            U[Convert.ToInt16('d')] = 'ვ'; U[Convert.ToInt16('f')] = 'ა'; U[Convert.ToInt16('g')] = 'პ';
            U[Convert.ToInt16('h')] = 'რ'; U[Convert.ToInt16('j')] = 'ო'; U[Convert.ToInt16('k')] = 'ლ';
            U[Convert.ToInt16('l')] = 'დ'; U[Convert.ToInt16('z')] = 'ჭ'; U[Convert.ToInt16('x')] = 'ჩ';
            U[Convert.ToInt16('c')] = 'ს'; U[Convert.ToInt16('v')] = 'მ'; U[Convert.ToInt16('b')] = 'ი';
            U[Convert.ToInt16('n')] = 'ტ'; U[Convert.ToInt16('m')] = 'ქ'; U[Convert.ToInt16(',')] = 'ბ';
            U[Convert.ToInt16('.')] = 'ყ'; U[Convert.ToInt16(';')] = 'ჟ'; U[Convert.ToInt16('\'')] = 'ძ';
            U[Convert.ToInt16('[')] = 'ხ'; U[Convert.ToInt16(']')] = 'ჯ'; U[Convert.ToInt16('$')] = ';';
            U[Convert.ToInt16('^')] = ':'; U[Convert.ToInt16('`')] = '~'; U[Convert.ToInt16('~')] = 'ჰ';
            U[Convert.ToInt16('&')] = '?';

        }

        static private void SetRussianU()
        {
            KeySet = KeyLayout.Russian;
            //C = new char[256];

            for (int i = 0; i <= 255; i++)
                U[i] = Convert.ToChar(i);


            U[Convert.ToInt16('q')] = 'й';
            U[Convert.ToInt16('w')] = 'ц';
            U[Convert.ToInt16('e')] = 'у';
            U[Convert.ToInt16('r')] = 'к';
            U[Convert.ToInt16('t')] = 'е';
            U[Convert.ToInt16('y')] = 'н';
            U[Convert.ToInt16('u')] = 'г';
            U[Convert.ToInt16('i')] = 'ш';
            U[Convert.ToInt16('o')] = 'щ';
            U[Convert.ToInt16('p')] = 'з';
            U[Convert.ToInt16('[')] = 'х';
            U[Convert.ToInt16(']')] = 'ъ';
            U[Convert.ToInt16('\\')] = '\\';

            U[Convert.ToInt16('a')] = 'ф';
            U[Convert.ToInt16('s')] = 'ы';
            U[Convert.ToInt16('d')] = 'в';
            U[Convert.ToInt16('f')] = 'а';
            U[Convert.ToInt16('g')] = 'п';
            U[Convert.ToInt16('h')] = 'р';
            U[Convert.ToInt16('j')] = 'о';
            U[Convert.ToInt16('k')] = 'л';
            U[Convert.ToInt16('l')] = 'д';
            U[Convert.ToInt16(';')] = 'ж';
            U[Convert.ToInt16('\'')] = 'э';

            U[Convert.ToInt16('z')] = 'я';
            U[Convert.ToInt16('x')] = 'ч';
            U[Convert.ToInt16('c')] = 'с';
            U[Convert.ToInt16('v')] = 'м';
            U[Convert.ToInt16('b')] = 'и';

            U[Convert.ToInt16('n')] = 'т';
            U[Convert.ToInt16('m')] = 'ь';
            U[Convert.ToInt16(',')] = 'б';
            U[Convert.ToInt16('.')] = 'ю';
            U[Convert.ToInt16('/')] = '.';

            U[Convert.ToInt16('`')] = '¸';

            U[Convert.ToInt16('~')] = '¨';
            U[Convert.ToInt16('!')] = '!';
            U[Convert.ToInt16('@')] = '"';
            U[Convert.ToInt16('#')] = '¹';
            U[Convert.ToInt16('$')] = ';';
            U[Convert.ToInt16('%')] = '%';
            U[Convert.ToInt16('^')] = ':';
            U[Convert.ToInt16('&')] = '?';
            U[Convert.ToInt16('*')] = '*';
            U[Convert.ToInt16('(')] = '(';
            U[Convert.ToInt16(')')] = ')';
            U[Convert.ToInt16('_')] = '_';
            U[Convert.ToInt16('+')] = '+';

            U[Convert.ToInt16('Q')] = 'Й';
            U[Convert.ToInt16('W')] = 'Ц';
            U[Convert.ToInt16('E')] = 'У';
            U[Convert.ToInt16('R')] = 'К';
            U[Convert.ToInt16('T')] = 'Е';
            U[Convert.ToInt16('Y')] = 'Н';
            U[Convert.ToInt16('U')] = 'Г';
            U[Convert.ToInt16('I')] = 'Ш';
            U[Convert.ToInt16('O')] = 'Щ';
            U[Convert.ToInt16('P')] = 'З';
            U[Convert.ToInt16('{')] = 'Х';
            U[Convert.ToInt16('}')] = 'Ъ';
            U[Convert.ToInt16('|')] = '/';

            U[Convert.ToInt16('A')] = 'Ф';
            U[Convert.ToInt16('S')] = 'Ы';
            U[Convert.ToInt16('D')] = 'В';
            U[Convert.ToInt16('F')] = 'А';
            U[Convert.ToInt16('G')] = 'П';
            U[Convert.ToInt16('H')] = 'Р';
            U[Convert.ToInt16('J')] = 'О';
            U[Convert.ToInt16('K')] = 'Л';
            U[Convert.ToInt16('L')] = 'Д';
            U[Convert.ToInt16(':')] = 'Ж';
            U[Convert.ToInt16('"')] = 'Э';

            U[Convert.ToInt16('Z')] = 'Я';
            U[Convert.ToInt16('X')] = 'Ч';
            U[Convert.ToInt16('C')] = 'С';
            U[Convert.ToInt16('V')] = 'М';
            U[Convert.ToInt16('B')] = 'И';
            U[Convert.ToInt16('N')] = 'Т';
            U[Convert.ToInt16('M')] = 'Ь';
            U[Convert.ToInt16('<')] = 'Б';
            U[Convert.ToInt16('>')] = 'Ю';
            U[Convert.ToInt16('?')] = ',';
        }

        #endregion 16 Bit Filter


    }
}