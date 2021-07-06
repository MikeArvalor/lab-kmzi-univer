using System;


namespace Enigma
{
    static class Enigmaaa
    {
        static char[,] rotor2Сonformity = new char[2, 26];
        static char[,] rotorGammaСonformity = new char[2, 26];
        static char[,] rotor4Сonformity = new char[2, 26];
        // FKQHTLXOCBJSPDZRAMEWNIUYGV
        // 'A', 'J', 'D', 'K', 'S', 'I', 'R', 'U', 'X', 'B', 'L', 'H', 'W', 'T', 'M', 'C', 'Q', 'G', 'Z', 'N', 'P', 'Y', 'F', 'V', 'O', 'E'};
        // OK
        // ESOVPZJAYQUIRHXLNFTGKDCMWB
        static char[] alphEng = new char[] {  'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J',
                                              'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T',
                                              'U', 'V', 'W', 'X', 'Y', 'Z'};
        static char[] rotor4 = new char[] { 'E', 'S', 'O', 'V', 'P', 'Z', 'J', 'A', 'Y', 'Q', 'U', 'I', 'R', 'H', 'X', 'L', 'N', 'F', 'T', 'G', 'K', 'D', 'C', 'M', 'W', 'B' };
       
        static char[] rotor3 = new char[]{ 'B', 'D', 'F', 'H', 'J', 'L', 'C', 'P', 'R', 'T', 'X', 'V', 'Z', 'N', 'Y', 'E', 'I', 'W', 'G', 'A', 'K', 'M', 'U', 'S', 'Q', 'O' };
        static char[] rotor2 = new char[] { 'A', 'J', 'D', 'K', 'S', 'I', 'R', 'U', 'X', 'B', 'L', 'H', 'W', 'T', 'M', 'C', 'Q', 'G', 'Z', 'N', 'P', 'Y', 'F', 'V', 'O', 'E' };
        static char[,] reflectorC = new char[,] { { 'A','R' }, { 'B', 'D' },
                                                  { 'C','O' }, { 'E', 'J' },
                                                  { 'F','N' }, { 'G','T' },
                                                  { 'H', 'K' }, { 'I', 'V' },
                                                  { 'L','M' }, { 'P', 'W' },
                                                  { 'Q','Z' }, { 'S', 'X' },
                                                  { 'U','Y' } };
        static int Li = 0, Mi = 0, Ri = 4;
        static int currentPositionL, currentPositionM, currentPositionR;
        static char[] startCombination = new char[3];
        static public void SetStartPossition(char a, char b, char c)
        {
            currentPositionL = Array.IndexOf(alphEng, a);
            currentPositionM = Array.IndexOf(alphEng, b);
            currentPositionR = Array.IndexOf(alphEng, c);
        }
        static public void AddPossition()
        {
            currentPositionL++;
            currentPositionM++;
            currentPositionR++;
        }
        static public void RotorsFilling()
        {
            for (int i = 0; i < 26; i++)
            {
                rotor2Сonformity[0, i] = rotor2[i];
                rotor2Сonformity[1, i] = alphEng[i];
                rotorGammaСonformity[0, i] = rotor3[i];
                rotorGammaСonformity[1, i] = alphEng[i];
                rotor4Сonformity[0, i] = rotor4[i];
                rotor4Сonformity[1, i] = alphEng[i];
            }
        }
        static public char DirectConversation_R_rotor(char a)
        {
            char current_letter = alphEng[(currentPositionR + Array.IndexOf(alphEng, a)) % 26];
            for (int i = 0; i < 26; i++)
            {
                if (rotor2Сonformity[1, i] == current_letter)
                    return rotor2Сonformity[0, i];
            }
            return '\0';
        }
        static public char DirectConversation_M_rotor(char a)
        {
            char current_letter;
            int res = Array.IndexOf(alphEng, a) + currentPositionM - currentPositionR;
            if (res < 0)
            {
                res += 26;
            }
            current_letter = alphEng[res % 26];
            for (int i = 0; i < 26; i++)
            {
                if (rotorGammaСonformity[1, i] == current_letter)
                    return rotorGammaСonformity[0, i];
            }
            return '\0';

        }
        static public char DirectConversation_L_rotor(char a)
        {
            char current_letter;
            int res = Array.IndexOf(alphEng, a) + currentPositionL - currentPositionM;
            if (res < 0)
            {
                res += 26;
            }
            current_letter = alphEng[res % 26];

            for (int i = 0; i < 26; i++)
            {
                if (rotor4Сonformity[1, i] == current_letter)
                    return rotor4Сonformity[0, i];
            }
            return '\0';

        }
        static public char Conversation_Reflector(char a)
        {
            int res = Array.IndexOf(alphEng, a) - currentPositionL;
            if (res < 0)
            {
                res += 26;
            }
            char current_letter = alphEng[res % 26];
            for (int i = 0; i < 13; i++)
            {
                if (reflectorC[i, 0] == current_letter)
                    return reflectorC[i, 1];
                if (reflectorC[i, 1] == current_letter)
                    return reflectorC[i, 0];
            }
            return '\0';
        }
        static public char BackConversation_L_rotor(char a)
        {
            char current_letter;
            int res = Array.IndexOf(alphEng, a) + currentPositionL;
            if (res < 0)
            {
                res += 26;
            }
            current_letter = alphEng[res % 26];
            for (int i = 0; i < 26; i++)
            {
                if (rotor4Сonformity[0, i] == current_letter)
                    return rotor4Сonformity[1, i];
            }
            return '\0';


        }
        static public char BackConversation_M_rotor(char a)
        {
            char current_letter;
            int res = Array.IndexOf(alphEng, a) - (currentPositionL - currentPositionM);
            if (res < 0)
            {
                res += 26;
            }
            current_letter = alphEng[res % 26];
            for (int i = 0; i < 26; i++)
            {
                if (rotorGammaСonformity[0, i] == current_letter)
                    return rotorGammaСonformity[1, i];
            }
            return '\0';

        }
        static public char BackConversation_R_rotor(char a)
        {
            char current_letter;
            int res = Array.IndexOf(alphEng, a) - (currentPositionM - currentPositionR);
            if (res < 0)
            {
                res += 26;
            }
            current_letter = alphEng[res % 26];
            for (int i = 0; i < 26; i++)
            {
                if (rotor2Сonformity[0, i] == current_letter)
                    return rotor2Сonformity[1, i];
            }
            return '\0';

        }
        static public char BackConversationFinish(char a)
        {
            int res = Array.IndexOf(alphEng, a) - currentPositionR;
            if (res < 0)
            {
                res += 26;
            }
            return alphEng[res % 26];

        }
        static public char Encryption(char a)
        {
            AddPossition();
            return (BackConversationFinish(
                    BackConversation_R_rotor(
                    BackConversation_M_rotor(
                    BackConversation_L_rotor(
                    Conversation_Reflector(
                    DirectConversation_L_rotor(
                    DirectConversation_M_rotor(
                    DirectConversation_R_rotor(a)))))))));
        }
    }
}
