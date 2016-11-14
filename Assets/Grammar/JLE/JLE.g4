grammar JLE;

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

NEWLINE:'\r'? '\n' { compiler.FunctionManager.oneMoreLine(); };
WS : [ \t\r\n]+ -> skip ;

start : prog EOF ;

prog : (function NEWLINE)+ function | function ;

function : (function_use SEMICOLON? { compiler.FunctionManager.ErrorManager.checkLineEnding($SEMICOLON.text); })
         | function_declaration;

function_use : identifier=STRING { compiler.FunctionManager.addFunctionUse($identifier.text); }
		   LEFTPAR
		   param_id_list?
		   RIGHTPAR {compiler.FunctionManager.addCommand($identifier.text, $param_id_list.text); };

function_declaration : function_type=STRING 
					   identifier=STRING {compiler.FunctionManager.addDeclaredFunction($identifier.text); }
					   LEFTPAR
					   param_decl_list?
					   RIGHTPAR
					   LEFTSQ
					   RIGHTSQ {compiler.FunctionManager.addNewFunction($function_type.text, $identifier.text, $param_decl_list.text); };
		   
param_id_list : (param_id COMMA)+ param_id | param_id ;

param_decl_list : (param_decl COMMA)+ param_decl | param_decl ;

param_decl : param_type=STRING param_identifier=STRING;

param_id : STRING | INT ;



