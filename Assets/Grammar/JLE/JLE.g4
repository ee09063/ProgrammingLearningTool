grammar JLE;

@members
{
	public Compiler compiler = new Compiler();
}

INT : '-'? ('0'..'9')+ ; 
STRING : [a-zA-Z_]+ ;
LEFTPAR : '(' ;
RIGHTPAR : ')' ;
SEMICOLON : ';' ;
COMMA : ',' ;

NEWLINE:'\r'? '\n' ;
WS : [ \t\r\n]+ -> skip ;

start : prog EOF ;

prog : (cmd NEWLINE)+ cmd | cmd ;

cmd : func 
	  SEMICOLON? { compiler.FunctionManager.ErrorManager.checkLineEnding($SEMICOLON.text); };

func : func_name=STRING { compiler.FunctionManager.addFunctionName($func_name.text); }
		LEFTPAR
		args?
		RIGHTPAR { compiler.FunctionManager.addGenericCommand($func_name.text, $args.text); };

args : (arg COMMA)+ arg | arg ;

arg : STRING | INT ;



