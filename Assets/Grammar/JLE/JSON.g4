grammar JSON;

@members
{
	public Compiler compiler = new Compiler();
}

INT : '-'? ('0'..'9')+ ;
STRING : [a-zA-Z_]+ ;
LEFTPAR : '(' ;
RIGHTPAR : ')' ;
LEFTSQ: '{' ;
RIGHTSQ : '}' ;
SEMICOLON : ';' ;
COMMA : ',' ;
LESSERTHAN : '<' ;
GREATERTHAN : '>' ;
PLUSPLUS: '++' ;
MINUSMINUS: '--' ;

WS : [ \t\r]+ -> skip ;
NEWLINE: [\n] ;


start
    : prog EOF
    ;

prog
    : (function)+ function
    | function
    ;

function
    : function_use
    | function_declaration
	| for_cycle_use
    ;

function_use
    : identifier=STRING
      LEFTPAR
      RIGHTPAR {compiler.functionManager.addFunctionToMaster($identifier.text); }
      SEMICOLON?
	  (NEWLINE { compiler.functionManager.addNewLine(); })*
    ;

function_inside_function
	: identifier=STRING
      LEFTPAR
      RIGHTPAR {compiler.functionManager.addFunctionToCurrentFunction($identifier.text); }
      SEMICOLON?
	  (NEWLINE { compiler.functionManager.addNewLine(); })*
    ;

function_declaration
    : function_type=STRING
      identifier=STRING {compiler.functionManager.addDeclaredFunction($identifier.text); }
	  LEFTPAR
	  RIGHTPAR
	  NEWLINE { compiler.functionManager.addNewLine(); }
	  LEFTSQ
	  NEWLINE { compiler.functionManager.addNewLine(); }
	  (function_inside_function | for_cycle_inside_function | NEWLINE {compiler.functionManager.addNewLine(); } )*
	  RIGHTSQ
	  (NEWLINE { compiler.functionManager.addNewLine(); })* 
	;

for_cycle_use
	: 'for'
	   LEFTPAR
	   'int' val_dec=STRING '=' val_init=INT SEMICOLON
	   val_use=STRING LESSERTHAN val_total=INT SEMICOLON
	   val_inc=STRING (PLUSPLUS | MINUSMINUS)
 	   RIGHTPAR { compiler.functionManager.addForCycle($val_dec.text, $val_init.text, $val_use.text, $val_total.text, $val_inc.text); }
	   NEWLINE { compiler.functionManager.addNewLine(); }
	   LEFTSQ
	   (function_inside_function | NEWLINE {compiler.functionManager.addNewLine(); } )*
	   RIGHTSQ { compiler.functionManager.addForCycleCommandsToMaster(); }
	   (NEWLINE { compiler.functionManager.addNewLine(); })* 
	;

for_cycle_inside_function
	: 'for'
	   LEFTPAR
	   'int' val_dec=STRING '=' val_init=INT SEMICOLON
	   val_use=STRING ( LESSERTHAN | GREATERTHAN ) val_total=INT SEMICOLON
	   val_inc=STRING ( PLUSPLUS | MINUSMINUS )
	   RIGHTPAR { compiler.functionManager.addForCycle($val_dec.text, $val_init.text, $val_use.text, $val_total.text, $val_inc.text); }
	   NEWLINE { compiler.functionManager.addNewLine(); }
	   LEFTSQ
	   (function_inside_function | NEWLINE {compiler.functionManager.addNewLine(); } )*
	   RIGHTSQ { compiler.functionManager.addForCycleCommandsToCurrentFunction(); }
	   (NEWLINE { compiler.functionManager.addNewLine(); })* 
	;