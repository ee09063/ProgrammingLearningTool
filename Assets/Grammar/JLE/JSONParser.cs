//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.5.3
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from JSON.g4 by ANTLR 4.5.3

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using System;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.5.3")]
[System.CLSCompliant(false)]
public partial class JSONParser : Parser {
	public const int
		T__0=1, T__1=2, T__2=3, INT=4, STRING=5, LEFTPAR=6, RIGHTPAR=7, LEFTSQ=8, 
		RIGHTSQ=9, SEMICOLON=10, COMMA=11, LESSERTHAN=12, GREATERTHAN=13, PLUSPLUS=14, 
		MINUSMINUS=15, WS=16, NEWLINE=17;
	public const int
		RULE_start = 0, RULE_prog = 1, RULE_function = 2, RULE_function_use = 3, 
		RULE_function_inside_function = 4, RULE_function_declaration = 5, RULE_for_cycle_use = 6, 
		RULE_for_cycle_inside_function = 7;
	public static readonly string[] ruleNames = {
		"start", "prog", "function", "function_use", "function_inside_function", 
		"function_declaration", "for_cycle_use", "for_cycle_inside_function"
	};

	private static readonly string[] _LiteralNames = {
		null, "'for'", "'int'", "'='", null, null, "'('", "')'", "'{'", "'}'", 
		"';'", "','", "'<'", "'>'", "'++'", "'--'"
	};
	private static readonly string[] _SymbolicNames = {
		null, null, null, null, "INT", "STRING", "LEFTPAR", "RIGHTPAR", "LEFTSQ", 
		"RIGHTSQ", "SEMICOLON", "COMMA", "LESSERTHAN", "GREATERTHAN", "PLUSPLUS", 
		"MINUSMINUS", "WS", "NEWLINE"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "JSON.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string SerializedAtn { get { return _serializedATN; } }


		public Compiler compiler = new Compiler();

	public JSONParser(ITokenStream input)
		: base(input)
	{
		Interpreter = new ParserATNSimulator(this,_ATN);
	}
	public partial class StartContext : ParserRuleContext {
		public ProgContext prog() {
			return GetRuleContext<ProgContext>(0);
		}
		public ITerminalNode Eof() { return GetToken(JSONParser.Eof, 0); }
		public StartContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_start; } }
		public override void EnterRule(IParseTreeListener listener) {
			IJSONListener typedListener = listener as IJSONListener;
			if (typedListener != null) typedListener.EnterStart(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IJSONListener typedListener = listener as IJSONListener;
			if (typedListener != null) typedListener.ExitStart(this);
		}
	}

	[RuleVersion(0)]
	public StartContext start() {
		StartContext _localctx = new StartContext(Context, State);
		EnterRule(_localctx, 0, RULE_start);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 16; prog();
			State = 17; Match(Eof);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class ProgContext : ParserRuleContext {
		public FunctionContext[] function() {
			return GetRuleContexts<FunctionContext>();
		}
		public FunctionContext function(int i) {
			return GetRuleContext<FunctionContext>(i);
		}
		public ProgContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_prog; } }
		public override void EnterRule(IParseTreeListener listener) {
			IJSONListener typedListener = listener as IJSONListener;
			if (typedListener != null) typedListener.EnterProg(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IJSONListener typedListener = listener as IJSONListener;
			if (typedListener != null) typedListener.ExitProg(this);
		}
	}

	[RuleVersion(0)]
	public ProgContext prog() {
		ProgContext _localctx = new ProgContext(Context, State);
		EnterRule(_localctx, 2, RULE_prog);
		try {
			int _alt;
			State = 27;
			ErrorHandler.Sync(this);
			switch ( Interpreter.AdaptivePredict(TokenStream,1,Context) ) {
			case 1:
				EnterOuterAlt(_localctx, 1);
				{
				State = 20;
				ErrorHandler.Sync(this);
				_alt = 1;
				do {
					switch (_alt) {
					case 1:
						{
						{
						State = 19; function();
						}
						}
						break;
					default:
						throw new NoViableAltException(this);
					}
					State = 22;
					ErrorHandler.Sync(this);
					_alt = Interpreter.AdaptivePredict(TokenStream,0,Context);
				} while ( _alt!=2 && _alt!=global::Antlr4.Runtime.Atn.ATN.InvalidAltNumber );
				State = 24; function();
				}
				break;
			case 2:
				EnterOuterAlt(_localctx, 2);
				{
				State = 26; function();
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class FunctionContext : ParserRuleContext {
		public Function_useContext function_use() {
			return GetRuleContext<Function_useContext>(0);
		}
		public Function_declarationContext function_declaration() {
			return GetRuleContext<Function_declarationContext>(0);
		}
		public For_cycle_useContext for_cycle_use() {
			return GetRuleContext<For_cycle_useContext>(0);
		}
		public FunctionContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_function; } }
		public override void EnterRule(IParseTreeListener listener) {
			IJSONListener typedListener = listener as IJSONListener;
			if (typedListener != null) typedListener.EnterFunction(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IJSONListener typedListener = listener as IJSONListener;
			if (typedListener != null) typedListener.ExitFunction(this);
		}
	}

	[RuleVersion(0)]
	public FunctionContext function() {
		FunctionContext _localctx = new FunctionContext(Context, State);
		EnterRule(_localctx, 4, RULE_function);
		try {
			State = 32;
			ErrorHandler.Sync(this);
			switch ( Interpreter.AdaptivePredict(TokenStream,2,Context) ) {
			case 1:
				EnterOuterAlt(_localctx, 1);
				{
				State = 29; function_use();
				}
				break;
			case 2:
				EnterOuterAlt(_localctx, 2);
				{
				State = 30; function_declaration();
				}
				break;
			case 3:
				EnterOuterAlt(_localctx, 3);
				{
				State = 31; for_cycle_use();
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class Function_useContext : ParserRuleContext {
		public IToken identifier;
		public ITerminalNode LEFTPAR() { return GetToken(JSONParser.LEFTPAR, 0); }
		public ITerminalNode RIGHTPAR() { return GetToken(JSONParser.RIGHTPAR, 0); }
		public ITerminalNode STRING() { return GetToken(JSONParser.STRING, 0); }
		public ITerminalNode SEMICOLON() { return GetToken(JSONParser.SEMICOLON, 0); }
		public ITerminalNode[] NEWLINE() { return GetTokens(JSONParser.NEWLINE); }
		public ITerminalNode NEWLINE(int i) {
			return GetToken(JSONParser.NEWLINE, i);
		}
		public Function_useContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_function_use; } }
		public override void EnterRule(IParseTreeListener listener) {
			IJSONListener typedListener = listener as IJSONListener;
			if (typedListener != null) typedListener.EnterFunction_use(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IJSONListener typedListener = listener as IJSONListener;
			if (typedListener != null) typedListener.ExitFunction_use(this);
		}
	}

	[RuleVersion(0)]
	public Function_useContext function_use() {
		Function_useContext _localctx = new Function_useContext(Context, State);
		EnterRule(_localctx, 6, RULE_function_use);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 34; _localctx.identifier = Match(STRING);
			State = 35; Match(LEFTPAR);
			State = 36; Match(RIGHTPAR);
			compiler.functionManager.addFunctionToMaster((_localctx.identifier!=null?_localctx.identifier.Text:null)); 
			State = 39;
			_la = TokenStream.La(1);
			if (_la==SEMICOLON) {
				{
				State = 38; Match(SEMICOLON);
				}
			}

			State = 45;
			ErrorHandler.Sync(this);
			_la = TokenStream.La(1);
			while (_la==NEWLINE) {
				{
				{
				State = 41; Match(NEWLINE);
				 compiler.functionManager.addNewLine(); 
				}
				}
				State = 47;
				ErrorHandler.Sync(this);
				_la = TokenStream.La(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class Function_inside_functionContext : ParserRuleContext {
		public IToken identifier;
		public ITerminalNode LEFTPAR() { return GetToken(JSONParser.LEFTPAR, 0); }
		public ITerminalNode RIGHTPAR() { return GetToken(JSONParser.RIGHTPAR, 0); }
		public ITerminalNode STRING() { return GetToken(JSONParser.STRING, 0); }
		public ITerminalNode SEMICOLON() { return GetToken(JSONParser.SEMICOLON, 0); }
		public ITerminalNode[] NEWLINE() { return GetTokens(JSONParser.NEWLINE); }
		public ITerminalNode NEWLINE(int i) {
			return GetToken(JSONParser.NEWLINE, i);
		}
		public Function_inside_functionContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_function_inside_function; } }
		public override void EnterRule(IParseTreeListener listener) {
			IJSONListener typedListener = listener as IJSONListener;
			if (typedListener != null) typedListener.EnterFunction_inside_function(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IJSONListener typedListener = listener as IJSONListener;
			if (typedListener != null) typedListener.ExitFunction_inside_function(this);
		}
	}

	[RuleVersion(0)]
	public Function_inside_functionContext function_inside_function() {
		Function_inside_functionContext _localctx = new Function_inside_functionContext(Context, State);
		EnterRule(_localctx, 8, RULE_function_inside_function);
		int _la;
		try {
			int _alt;
			EnterOuterAlt(_localctx, 1);
			{
			State = 48; _localctx.identifier = Match(STRING);
			State = 49; Match(LEFTPAR);
			State = 50; Match(RIGHTPAR);
			compiler.functionManager.addFunctionToCurrentFunction((_localctx.identifier!=null?_localctx.identifier.Text:null)); 
			State = 53;
			_la = TokenStream.La(1);
			if (_la==SEMICOLON) {
				{
				State = 52; Match(SEMICOLON);
				}
			}

			State = 59;
			ErrorHandler.Sync(this);
			_alt = Interpreter.AdaptivePredict(TokenStream,6,Context);
			while ( _alt!=2 && _alt!=global::Antlr4.Runtime.Atn.ATN.InvalidAltNumber ) {
				if ( _alt==1 ) {
					{
					{
					State = 55; Match(NEWLINE);
					 compiler.functionManager.addNewLine(); 
					}
					} 
				}
				State = 61;
				ErrorHandler.Sync(this);
				_alt = Interpreter.AdaptivePredict(TokenStream,6,Context);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class Function_declarationContext : ParserRuleContext {
		public IToken function_type;
		public IToken identifier;
		public ITerminalNode LEFTPAR() { return GetToken(JSONParser.LEFTPAR, 0); }
		public ITerminalNode RIGHTPAR() { return GetToken(JSONParser.RIGHTPAR, 0); }
		public ITerminalNode[] NEWLINE() { return GetTokens(JSONParser.NEWLINE); }
		public ITerminalNode NEWLINE(int i) {
			return GetToken(JSONParser.NEWLINE, i);
		}
		public ITerminalNode LEFTSQ() { return GetToken(JSONParser.LEFTSQ, 0); }
		public ITerminalNode RIGHTSQ() { return GetToken(JSONParser.RIGHTSQ, 0); }
		public ITerminalNode[] STRING() { return GetTokens(JSONParser.STRING); }
		public ITerminalNode STRING(int i) {
			return GetToken(JSONParser.STRING, i);
		}
		public Function_inside_functionContext[] function_inside_function() {
			return GetRuleContexts<Function_inside_functionContext>();
		}
		public Function_inside_functionContext function_inside_function(int i) {
			return GetRuleContext<Function_inside_functionContext>(i);
		}
		public For_cycle_inside_functionContext[] for_cycle_inside_function() {
			return GetRuleContexts<For_cycle_inside_functionContext>();
		}
		public For_cycle_inside_functionContext for_cycle_inside_function(int i) {
			return GetRuleContext<For_cycle_inside_functionContext>(i);
		}
		public Function_declarationContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_function_declaration; } }
		public override void EnterRule(IParseTreeListener listener) {
			IJSONListener typedListener = listener as IJSONListener;
			if (typedListener != null) typedListener.EnterFunction_declaration(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IJSONListener typedListener = listener as IJSONListener;
			if (typedListener != null) typedListener.ExitFunction_declaration(this);
		}
	}

	[RuleVersion(0)]
	public Function_declarationContext function_declaration() {
		Function_declarationContext _localctx = new Function_declarationContext(Context, State);
		EnterRule(_localctx, 10, RULE_function_declaration);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 62; _localctx.function_type = Match(STRING);
			State = 63; _localctx.identifier = Match(STRING);
			compiler.functionManager.addDeclaredFunction((_localctx.identifier!=null?_localctx.identifier.Text:null)); 
			State = 65; Match(LEFTPAR);
			State = 66; Match(RIGHTPAR);
			State = 67; Match(NEWLINE);
			 compiler.functionManager.addNewLine(); 
			State = 69; Match(LEFTSQ);
			State = 70; Match(NEWLINE);
			 compiler.functionManager.addNewLine(); 
			State = 78;
			ErrorHandler.Sync(this);
			_la = TokenStream.La(1);
			while ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << T__0) | (1L << STRING) | (1L << NEWLINE))) != 0)) {
				{
				State = 76;
				switch (TokenStream.La(1)) {
				case STRING:
					{
					State = 72; function_inside_function();
					}
					break;
				case T__0:
					{
					State = 73; for_cycle_inside_function();
					}
					break;
				case NEWLINE:
					{
					State = 74; Match(NEWLINE);
					compiler.functionManager.addNewLine(); 
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				}
				State = 80;
				ErrorHandler.Sync(this);
				_la = TokenStream.La(1);
			}
			State = 81; Match(RIGHTSQ);
			State = 86;
			ErrorHandler.Sync(this);
			_la = TokenStream.La(1);
			while (_la==NEWLINE) {
				{
				{
				State = 82; Match(NEWLINE);
				 compiler.functionManager.addNewLine(); 
				}
				}
				State = 88;
				ErrorHandler.Sync(this);
				_la = TokenStream.La(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class For_cycle_useContext : ParserRuleContext {
		public IToken val_dec;
		public IToken val_init;
		public IToken val_use;
		public IToken val_total;
		public IToken val_inc;
		public IToken val_inc_symb;
		public ITerminalNode LEFTPAR() { return GetToken(JSONParser.LEFTPAR, 0); }
		public ITerminalNode[] SEMICOLON() { return GetTokens(JSONParser.SEMICOLON); }
		public ITerminalNode SEMICOLON(int i) {
			return GetToken(JSONParser.SEMICOLON, i);
		}
		public ITerminalNode LESSERTHAN() { return GetToken(JSONParser.LESSERTHAN, 0); }
		public ITerminalNode RIGHTPAR() { return GetToken(JSONParser.RIGHTPAR, 0); }
		public ITerminalNode[] NEWLINE() { return GetTokens(JSONParser.NEWLINE); }
		public ITerminalNode NEWLINE(int i) {
			return GetToken(JSONParser.NEWLINE, i);
		}
		public ITerminalNode LEFTSQ() { return GetToken(JSONParser.LEFTSQ, 0); }
		public ITerminalNode RIGHTSQ() { return GetToken(JSONParser.RIGHTSQ, 0); }
		public ITerminalNode[] STRING() { return GetTokens(JSONParser.STRING); }
		public ITerminalNode STRING(int i) {
			return GetToken(JSONParser.STRING, i);
		}
		public ITerminalNode[] INT() { return GetTokens(JSONParser.INT); }
		public ITerminalNode INT(int i) {
			return GetToken(JSONParser.INT, i);
		}
		public ITerminalNode PLUSPLUS() { return GetToken(JSONParser.PLUSPLUS, 0); }
		public ITerminalNode MINUSMINUS() { return GetToken(JSONParser.MINUSMINUS, 0); }
		public Function_inside_functionContext[] function_inside_function() {
			return GetRuleContexts<Function_inside_functionContext>();
		}
		public Function_inside_functionContext function_inside_function(int i) {
			return GetRuleContext<Function_inside_functionContext>(i);
		}
		public For_cycle_useContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_for_cycle_use; } }
		public override void EnterRule(IParseTreeListener listener) {
			IJSONListener typedListener = listener as IJSONListener;
			if (typedListener != null) typedListener.EnterFor_cycle_use(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IJSONListener typedListener = listener as IJSONListener;
			if (typedListener != null) typedListener.ExitFor_cycle_use(this);
		}
	}

	[RuleVersion(0)]
	public For_cycle_useContext for_cycle_use() {
		For_cycle_useContext _localctx = new For_cycle_useContext(Context, State);
		EnterRule(_localctx, 12, RULE_for_cycle_use);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 89; Match(T__0);
			State = 90; Match(LEFTPAR);
			State = 91; Match(T__1);
			State = 92; _localctx.val_dec = Match(STRING);
			State = 93; Match(T__2);
			State = 94; _localctx.val_init = Match(INT);
			State = 95; Match(SEMICOLON);
			State = 96; _localctx.val_use = Match(STRING);
			State = 97; Match(LESSERTHAN);
			State = 98; _localctx.val_total = Match(INT);
			State = 99; Match(SEMICOLON);
			State = 100; _localctx.val_inc = Match(STRING);
			State = 101;
			_localctx.val_inc_symb = TokenStream.Lt(1);
			_la = TokenStream.La(1);
			if ( !(_la==PLUSPLUS || _la==MINUSMINUS) ) {
				_localctx.val_inc_symb = ErrorHandler.RecoverInline(this);
			}
			else {
			    Consume();
			}
			State = 102; Match(RIGHTPAR);
			 compiler.functionManager.addForCycle((_localctx.val_dec!=null?_localctx.val_dec.Text:null), (_localctx.val_init!=null?_localctx.val_init.Text:null), (_localctx.val_use!=null?_localctx.val_use.Text:null), (_localctx.val_total!=null?_localctx.val_total.Text:null), (_localctx.val_inc!=null?_localctx.val_inc.Text:null), (_localctx.val_inc_symb!=null?_localctx.val_inc_symb.Text:null)); 
			State = 104; Match(NEWLINE);
			 compiler.functionManager.addNewLine(); 
			State = 106; Match(LEFTSQ);
			State = 112;
			ErrorHandler.Sync(this);
			_la = TokenStream.La(1);
			while (_la==STRING || _la==NEWLINE) {
				{
				State = 110;
				switch (TokenStream.La(1)) {
				case STRING:
					{
					State = 107; function_inside_function();
					}
					break;
				case NEWLINE:
					{
					State = 108; Match(NEWLINE);
					compiler.functionManager.addNewLine(); 
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				}
				State = 114;
				ErrorHandler.Sync(this);
				_la = TokenStream.La(1);
			}
			State = 115; Match(RIGHTSQ);
			 compiler.functionManager.addForCycleCommandsToMaster(); 
			State = 121;
			ErrorHandler.Sync(this);
			_la = TokenStream.La(1);
			while (_la==NEWLINE) {
				{
				{
				State = 117; Match(NEWLINE);
				 compiler.functionManager.addNewLine(); 
				}
				}
				State = 123;
				ErrorHandler.Sync(this);
				_la = TokenStream.La(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class For_cycle_inside_functionContext : ParserRuleContext {
		public IToken val_dec;
		public IToken val_init;
		public IToken val_use;
		public IToken val_total;
		public IToken val_inc;
		public IToken val_inc_symb;
		public ITerminalNode LEFTPAR() { return GetToken(JSONParser.LEFTPAR, 0); }
		public ITerminalNode[] SEMICOLON() { return GetTokens(JSONParser.SEMICOLON); }
		public ITerminalNode SEMICOLON(int i) {
			return GetToken(JSONParser.SEMICOLON, i);
		}
		public ITerminalNode RIGHTPAR() { return GetToken(JSONParser.RIGHTPAR, 0); }
		public ITerminalNode[] NEWLINE() { return GetTokens(JSONParser.NEWLINE); }
		public ITerminalNode NEWLINE(int i) {
			return GetToken(JSONParser.NEWLINE, i);
		}
		public ITerminalNode LEFTSQ() { return GetToken(JSONParser.LEFTSQ, 0); }
		public ITerminalNode RIGHTSQ() { return GetToken(JSONParser.RIGHTSQ, 0); }
		public ITerminalNode[] STRING() { return GetTokens(JSONParser.STRING); }
		public ITerminalNode STRING(int i) {
			return GetToken(JSONParser.STRING, i);
		}
		public ITerminalNode[] INT() { return GetTokens(JSONParser.INT); }
		public ITerminalNode INT(int i) {
			return GetToken(JSONParser.INT, i);
		}
		public ITerminalNode LESSERTHAN() { return GetToken(JSONParser.LESSERTHAN, 0); }
		public ITerminalNode GREATERTHAN() { return GetToken(JSONParser.GREATERTHAN, 0); }
		public ITerminalNode PLUSPLUS() { return GetToken(JSONParser.PLUSPLUS, 0); }
		public ITerminalNode MINUSMINUS() { return GetToken(JSONParser.MINUSMINUS, 0); }
		public Function_inside_functionContext[] function_inside_function() {
			return GetRuleContexts<Function_inside_functionContext>();
		}
		public Function_inside_functionContext function_inside_function(int i) {
			return GetRuleContext<Function_inside_functionContext>(i);
		}
		public For_cycle_inside_functionContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_for_cycle_inside_function; } }
		public override void EnterRule(IParseTreeListener listener) {
			IJSONListener typedListener = listener as IJSONListener;
			if (typedListener != null) typedListener.EnterFor_cycle_inside_function(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IJSONListener typedListener = listener as IJSONListener;
			if (typedListener != null) typedListener.ExitFor_cycle_inside_function(this);
		}
	}

	[RuleVersion(0)]
	public For_cycle_inside_functionContext for_cycle_inside_function() {
		For_cycle_inside_functionContext _localctx = new For_cycle_inside_functionContext(Context, State);
		EnterRule(_localctx, 14, RULE_for_cycle_inside_function);
		int _la;
		try {
			int _alt;
			EnterOuterAlt(_localctx, 1);
			{
			State = 124; Match(T__0);
			State = 125; Match(LEFTPAR);
			State = 126; Match(T__1);
			State = 127; _localctx.val_dec = Match(STRING);
			State = 128; Match(T__2);
			State = 129; _localctx.val_init = Match(INT);
			State = 130; Match(SEMICOLON);
			State = 131; _localctx.val_use = Match(STRING);
			State = 132;
			_la = TokenStream.La(1);
			if ( !(_la==LESSERTHAN || _la==GREATERTHAN) ) {
			ErrorHandler.RecoverInline(this);
			}
			else {
			    Consume();
			}
			State = 133; _localctx.val_total = Match(INT);
			State = 134; Match(SEMICOLON);
			State = 135; _localctx.val_inc = Match(STRING);
			State = 136;
			_localctx.val_inc_symb = TokenStream.Lt(1);
			_la = TokenStream.La(1);
			if ( !(_la==PLUSPLUS || _la==MINUSMINUS) ) {
				_localctx.val_inc_symb = ErrorHandler.RecoverInline(this);
			}
			else {
			    Consume();
			}
			State = 137; Match(RIGHTPAR);
			 compiler.functionManager.addForCycle((_localctx.val_dec!=null?_localctx.val_dec.Text:null), (_localctx.val_init!=null?_localctx.val_init.Text:null), (_localctx.val_use!=null?_localctx.val_use.Text:null), (_localctx.val_total!=null?_localctx.val_total.Text:null), (_localctx.val_inc!=null?_localctx.val_inc.Text:null),  (_localctx.val_inc_symb!=null?_localctx.val_inc_symb.Text:null)); 
			State = 139; Match(NEWLINE);
			 compiler.functionManager.addNewLine(); 
			State = 141; Match(LEFTSQ);
			State = 147;
			ErrorHandler.Sync(this);
			_la = TokenStream.La(1);
			while (_la==STRING || _la==NEWLINE) {
				{
				State = 145;
				switch (TokenStream.La(1)) {
				case STRING:
					{
					State = 142; function_inside_function();
					}
					break;
				case NEWLINE:
					{
					State = 143; Match(NEWLINE);
					compiler.functionManager.addNewLine(); 
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				}
				State = 149;
				ErrorHandler.Sync(this);
				_la = TokenStream.La(1);
			}
			State = 150; Match(RIGHTSQ);
			 compiler.functionManager.addForCycleCommandsToCurrentFunction(); 
			State = 156;
			ErrorHandler.Sync(this);
			_alt = Interpreter.AdaptivePredict(TokenStream,15,Context);
			while ( _alt!=2 && _alt!=global::Antlr4.Runtime.Atn.ATN.InvalidAltNumber ) {
				if ( _alt==1 ) {
					{
					{
					State = 152; Match(NEWLINE);
					 compiler.functionManager.addNewLine(); 
					}
					} 
				}
				State = 158;
				ErrorHandler.Sync(this);
				_alt = Interpreter.AdaptivePredict(TokenStream,15,Context);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	private static string _serializedATN = _serializeATN();
	private static string _serializeATN()
	{
	    StringBuilder sb = new StringBuilder();
	    sb.Append("\x3\x430\xD6D1\x8206\xAD2D\x4417\xAEF1\x8D80\xAADD\x3\x13");
		sb.Append("\xA2\x4\x2\t\x2\x4\x3\t\x3\x4\x4\t\x4\x4\x5\t\x5\x4\x6\t\x6");
		sb.Append("\x4\a\t\a\x4\b\t\b\x4\t\t\t\x3\x2\x3\x2\x3\x2\x3\x3\x6\x3\x17");
		sb.Append("\n\x3\r\x3\xE\x3\x18\x3\x3\x3\x3\x3\x3\x5\x3\x1E\n\x3\x3\x4");
		sb.Append("\x3\x4\x3\x4\x5\x4#\n\x4\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x5\x5");
		sb.Append("*\n\x5\x3\x5\x3\x5\a\x5.\n\x5\f\x5\xE\x5\x31\v\x5\x3\x6\x3\x6");
		sb.Append("\x3\x6\x3\x6\x3\x6\x5\x6\x38\n\x6\x3\x6\x3\x6\a\x6<\n\x6\f\x6");
		sb.Append("\xE\x6?\v\x6\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3");
		sb.Append("\a\x3\a\x3\a\x3\a\x3\a\a\aO\n\a\f\a\xE\aR\v\a\x3\a\x3\a\x3\a");
		sb.Append("\a\aW\n\a\f\a\xE\aZ\v\a\x3\b\x3\b\x3\b\x3\b\x3\b\x3\b\x3\b\x3");
		sb.Append("\b\x3\b\x3\b\x3\b\x3\b\x3\b\x3\b\x3\b\x3\b\x3\b\x3\b\x3\b\x3");
		sb.Append("\b\x3\b\a\bq\n\b\f\b\xE\bt\v\b\x3\b\x3\b\x3\b\x3\b\a\bz\n\b");
		sb.Append("\f\b\xE\b}\v\b\x3\t\x3\t\x3\t\x3\t\x3\t\x3\t\x3\t\x3\t\x3\t");
		sb.Append("\x3\t\x3\t\x3\t\x3\t\x3\t\x3\t\x3\t\x3\t\x3\t\x3\t\x3\t\x3\t");
		sb.Append("\a\t\x94\n\t\f\t\xE\t\x97\v\t\x3\t\x3\t\x3\t\x3\t\a\t\x9D\n");
		sb.Append("\t\f\t\xE\t\xA0\v\t\x3\t\x2\x2\n\x2\x4\x6\b\n\f\xE\x10\x2\x4");
		sb.Append("\x3\x2\x10\x11\x3\x2\xE\xF\xAB\x2\x12\x3\x2\x2\x2\x4\x1D\x3");
		sb.Append("\x2\x2\x2\x6\"\x3\x2\x2\x2\b$\x3\x2\x2\x2\n\x32\x3\x2\x2\x2");
		sb.Append("\f@\x3\x2\x2\x2\xE[\x3\x2\x2\x2\x10~\x3\x2\x2\x2\x12\x13\x5");
		sb.Append("\x4\x3\x2\x13\x14\a\x2\x2\x3\x14\x3\x3\x2\x2\x2\x15\x17\x5\x6");
		sb.Append("\x4\x2\x16\x15\x3\x2\x2\x2\x17\x18\x3\x2\x2\x2\x18\x16\x3\x2");
		sb.Append("\x2\x2\x18\x19\x3\x2\x2\x2\x19\x1A\x3\x2\x2\x2\x1A\x1B\x5\x6");
		sb.Append("\x4\x2\x1B\x1E\x3\x2\x2\x2\x1C\x1E\x5\x6\x4\x2\x1D\x16\x3\x2");
		sb.Append("\x2\x2\x1D\x1C\x3\x2\x2\x2\x1E\x5\x3\x2\x2\x2\x1F#\x5\b\x5\x2");
		sb.Append(" #\x5\f\a\x2!#\x5\xE\b\x2\"\x1F\x3\x2\x2\x2\" \x3\x2\x2\x2\"");
		sb.Append("!\x3\x2\x2\x2#\a\x3\x2\x2\x2$%\a\a\x2\x2%&\a\b\x2\x2&\'\a\t");
		sb.Append("\x2\x2\')\b\x5\x1\x2(*\a\f\x2\x2)(\x3\x2\x2\x2)*\x3\x2\x2\x2");
		sb.Append("*/\x3\x2\x2\x2+,\a\x13\x2\x2,.\b\x5\x1\x2-+\x3\x2\x2\x2.\x31");
		sb.Append("\x3\x2\x2\x2/-\x3\x2\x2\x2/\x30\x3\x2\x2\x2\x30\t\x3\x2\x2\x2");
		sb.Append("\x31/\x3\x2\x2\x2\x32\x33\a\a\x2\x2\x33\x34\a\b\x2\x2\x34\x35");
		sb.Append("\a\t\x2\x2\x35\x37\b\x6\x1\x2\x36\x38\a\f\x2\x2\x37\x36\x3\x2");
		sb.Append("\x2\x2\x37\x38\x3\x2\x2\x2\x38=\x3\x2\x2\x2\x39:\a\x13\x2\x2");
		sb.Append(":<\b\x6\x1\x2;\x39\x3\x2\x2\x2<?\x3\x2\x2\x2=;\x3\x2\x2\x2=");
		sb.Append(">\x3\x2\x2\x2>\v\x3\x2\x2\x2?=\x3\x2\x2\x2@\x41\a\a\x2\x2\x41");
		sb.Append("\x42\a\a\x2\x2\x42\x43\b\a\x1\x2\x43\x44\a\b\x2\x2\x44\x45\a");
		sb.Append("\t\x2\x2\x45\x46\a\x13\x2\x2\x46G\b\a\x1\x2GH\a\n\x2\x2HI\a");
		sb.Append("\x13\x2\x2IP\b\a\x1\x2JO\x5\n\x6\x2KO\x5\x10\t\x2LM\a\x13\x2");
		sb.Append("\x2MO\b\a\x1\x2NJ\x3\x2\x2\x2NK\x3\x2\x2\x2NL\x3\x2\x2\x2OR");
		sb.Append("\x3\x2\x2\x2PN\x3\x2\x2\x2PQ\x3\x2\x2\x2QS\x3\x2\x2\x2RP\x3");
		sb.Append("\x2\x2\x2SX\a\v\x2\x2TU\a\x13\x2\x2UW\b\a\x1\x2VT\x3\x2\x2\x2");
		sb.Append("WZ\x3\x2\x2\x2XV\x3\x2\x2\x2XY\x3\x2\x2\x2Y\r\x3\x2\x2\x2ZX");
		sb.Append("\x3\x2\x2\x2[\\\a\x3\x2\x2\\]\a\b\x2\x2]^\a\x4\x2\x2^_\a\a\x2");
		sb.Append("\x2_`\a\x5\x2\x2`\x61\a\x6\x2\x2\x61\x62\a\f\x2\x2\x62\x63\a");
		sb.Append("\a\x2\x2\x63\x64\a\xE\x2\x2\x64\x65\a\x6\x2\x2\x65\x66\a\f\x2");
		sb.Append("\x2\x66g\a\a\x2\x2gh\t\x2\x2\x2hi\a\t\x2\x2ij\b\b\x1\x2jk\a");
		sb.Append("\x13\x2\x2kl\b\b\x1\x2lr\a\n\x2\x2mq\x5\n\x6\x2no\a\x13\x2\x2");
		sb.Append("oq\b\b\x1\x2pm\x3\x2\x2\x2pn\x3\x2\x2\x2qt\x3\x2\x2\x2rp\x3");
		sb.Append("\x2\x2\x2rs\x3\x2\x2\x2su\x3\x2\x2\x2tr\x3\x2\x2\x2uv\a\v\x2");
		sb.Append("\x2v{\b\b\x1\x2wx\a\x13\x2\x2xz\b\b\x1\x2yw\x3\x2\x2\x2z}\x3");
		sb.Append("\x2\x2\x2{y\x3\x2\x2\x2{|\x3\x2\x2\x2|\xF\x3\x2\x2\x2}{\x3\x2");
		sb.Append("\x2\x2~\x7F\a\x3\x2\x2\x7F\x80\a\b\x2\x2\x80\x81\a\x4\x2\x2");
		sb.Append("\x81\x82\a\a\x2\x2\x82\x83\a\x5\x2\x2\x83\x84\a\x6\x2\x2\x84");
		sb.Append("\x85\a\f\x2\x2\x85\x86\a\a\x2\x2\x86\x87\t\x3\x2\x2\x87\x88");
		sb.Append("\a\x6\x2\x2\x88\x89\a\f\x2\x2\x89\x8A\a\a\x2\x2\x8A\x8B\t\x2");
		sb.Append("\x2\x2\x8B\x8C\a\t\x2\x2\x8C\x8D\b\t\x1\x2\x8D\x8E\a\x13\x2");
		sb.Append("\x2\x8E\x8F\b\t\x1\x2\x8F\x95\a\n\x2\x2\x90\x94\x5\n\x6\x2\x91");
		sb.Append("\x92\a\x13\x2\x2\x92\x94\b\t\x1\x2\x93\x90\x3\x2\x2\x2\x93\x91");
		sb.Append("\x3\x2\x2\x2\x94\x97\x3\x2\x2\x2\x95\x93\x3\x2\x2\x2\x95\x96");
		sb.Append("\x3\x2\x2\x2\x96\x98\x3\x2\x2\x2\x97\x95\x3\x2\x2\x2\x98\x99");
		sb.Append("\a\v\x2\x2\x99\x9E\b\t\x1\x2\x9A\x9B\a\x13\x2\x2\x9B\x9D\b\t");
		sb.Append("\x1\x2\x9C\x9A\x3\x2\x2\x2\x9D\xA0\x3\x2\x2\x2\x9E\x9C\x3\x2");
		sb.Append("\x2\x2\x9E\x9F\x3\x2\x2\x2\x9F\x11\x3\x2\x2\x2\xA0\x9E\x3\x2");
		sb.Append("\x2\x2\x12\x18\x1D\")/\x37=NPXpr{\x93\x95\x9E");
	    return sb.ToString();
	}

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN.ToCharArray());
}
