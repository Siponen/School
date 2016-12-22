using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
    /*
     * Splits a string into words or symbols (aka tokens) by a specified char separator.
     */
    class Tokenizer
    {
        private string[] tokens;
        private int numTokens = 0;

        public void Split(string content, char separator)
        {
            tokens = content.Split(separator);
            numTokens = tokens.Length;
        }

        public string GetToken(int tokenNumber)
        {
            if(tokenNumber < numTokens)
                return tokens[tokenNumber];

            return "";
        }
    }
}
