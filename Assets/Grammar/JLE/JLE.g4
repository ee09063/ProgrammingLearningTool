grammar JLE;

@members
{
	public Compiler compiler = new Compiler();
}

prog : cmd+ ;

cmd : func SEMICOLON NEWLINE ;

func : IDENTIFIER LEFTPAR ARGS RIGHTPAR { compiler.addGenericCommand($IDENTIFIER.text, $ARGS.text); };

ARGS : (ARG COMMA)+ ARG | ARG ;
ARG : DIR | ANG ;

DIR : 'MOV_FWD' | 'MOV_BWD' ;
ANG : INT ;

INT : '-'? ('0'..'9')+ ; 
IDENTIFIER : [a-zA-Z]+ ;

LEFTPAR : '(' ;
RIGHTPAR : ')' ;
SEMICOLON : ';' ;
COMMA : ',' ;

NEWLINE:'\r'? '\n' ;
WS : [ \t\r\n]+ -> skip ;