using UnityEngine;
using System.Collections;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using System.Collections.Generic;

public class Compiler
{
    public FunctionManager functionManager;

    public Compiler()
    {
        functionManager = new FunctionManager();
    }

    public Program Compile(string source)
    {
        GameObject.FindGameObjectWithTag("LineCounter").GetComponent<LineCounter>().resetCount();

        AntlrInputStream antlrStream = new AntlrInputStream(source);
        JSONLexer lexer = new JSONLexer(antlrStream);
        CommonTokenStream tokenStream = new CommonTokenStream(lexer);
        JSONParser parser = new JSONParser(tokenStream);

        parser.prog();
        Compiler compiler = parser.compiler;
        		
        Program program = new Program(compiler.functionManager.Commands);

        if (compiler.functionManager.errorManager.hasErrors())
        {
            return null;
        }

        return program;
    }
}