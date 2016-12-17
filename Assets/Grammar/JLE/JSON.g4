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

WS : [ \t\r\n]+ -> skip ;

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
      RIGHTPAR {compiler.FunctionManager.addFunctionToMaster($identifier.text); }
      SEMICOLON { compiler.FunctionManager.ErrorManager.checkLineEnding($SEMICOLON.text); }
    ;

function_inside_function
	: identifier=STRING
      LEFTPAR
      RIGHTPAR {compiler.FunctionManager.addFunctionToCurrentFunction($identifier.text); }
      SEMICOLON { compiler.FunctionManager.ErrorManager.checkLineEnding($SEMICOLON.text); }
    ;

function_declaration
    : function_type=STRING
      identifier=STRING {compiler.FunctionManager.addDeclaredFunction($identifier.text); }
	  LEFTPAR
	  RIGHTPAR
	  LEFTSQ
	  (function_inside_function | for_cycle_inside_function)*
	  RIGHTSQ
	;

for_cycle_use
	: 'for'
	   LEFTPAR
	   'int' val_dec=STRING '=' val_init=INT SEMICOLON
	   val_use=STRING LESSERTHAN val_total=INT SEMICOLON
	   val_inc=STRING (PLUSPLUS | MINUSMINUS)
 	   RIGHTPAR { compiler.FunctionManager.addForCycle($val_dec.text, $val_init.text, $val_use.text, $val_total.text, $val_inc.text); }
	   LEFTSQ
	   function_inside_function*
	   RIGHTSQ { compiler.FunctionManager.addForCycleCommandsToMaster(); }
	;

for_cycle_inside_function
	: 'for'
	   LEFTPAR
	   'int' val_dec=STRING '=' val_init=INT SEMICOLON
	   val_use=STRING LESSERTHAN val_total=INT SEMICOLON
	   val_inc=STRING (PLUSPLUS | MINUSMINUS)
	   RIGHTPAR { compiler.FunctionManager.addForCycle($val_dec.text, $val_init.text, $val_use.text, $val_total.text, $val_inc.text); }
	   LEFTSQ
	   function_inside_function*
	   RIGHTSQ { compiler.FunctionManager.addForCycleCommandsToCurrentFunction(); }
	;

statement_list
    : statement_list statement
    |
    ;

statement
    : function_use
    ;