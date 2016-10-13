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
	  SEMICOLON? { compiler.checkLineEnding($SEMICOLON.text); };

func : func_name=STRING
		LEFTPAR
		args
		RIGHTPAR { compiler.addGenericCommand($func_name.text, $args.text); };

args : (arg COMMA)+ arg | arg ;

arg : STRING | INT ;



