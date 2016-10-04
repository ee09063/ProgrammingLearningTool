// Generated from JLE.g4 by ANTLR 4.5.3
import org.antlr.v4.runtime.tree.ParseTreeListener;

/**
 * This interface defines a complete listener for a parse tree produced by
 * {@link JLEParser}.
 */
public interface JLEListener extends ParseTreeListener {
	/**
	 * Enter a parse tree produced by {@link JLEParser#start}.
	 * @param ctx the parse tree
	 */
	void enterStart(JLEParser.StartContext ctx);
	/**
	 * Exit a parse tree produced by {@link JLEParser#start}.
	 * @param ctx the parse tree
	 */
	void exitStart(JLEParser.StartContext ctx);
	/**
	 * Enter a parse tree produced by {@link JLEParser#prog}.
	 * @param ctx the parse tree
	 */
	void enterProg(JLEParser.ProgContext ctx);
	/**
	 * Exit a parse tree produced by {@link JLEParser#prog}.
	 * @param ctx the parse tree
	 */
	void exitProg(JLEParser.ProgContext ctx);
	/**
	 * Enter a parse tree produced by {@link JLEParser#cmd}.
	 * @param ctx the parse tree
	 */
	void enterCmd(JLEParser.CmdContext ctx);
	/**
	 * Exit a parse tree produced by {@link JLEParser#cmd}.
	 * @param ctx the parse tree
	 */
	void exitCmd(JLEParser.CmdContext ctx);
	/**
	 * Enter a parse tree produced by {@link JLEParser#func}.
	 * @param ctx the parse tree
	 */
	void enterFunc(JLEParser.FuncContext ctx);
	/**
	 * Exit a parse tree produced by {@link JLEParser#func}.
	 * @param ctx the parse tree
	 */
	void exitFunc(JLEParser.FuncContext ctx);
	/**
	 * Enter a parse tree produced by {@link JLEParser#args}.
	 * @param ctx the parse tree
	 */
	void enterArgs(JLEParser.ArgsContext ctx);
	/**
	 * Exit a parse tree produced by {@link JLEParser#args}.
	 * @param ctx the parse tree
	 */
	void exitArgs(JLEParser.ArgsContext ctx);
	/**
	 * Enter a parse tree produced by {@link JLEParser#arg}.
	 * @param ctx the parse tree
	 */
	void enterArg(JLEParser.ArgContext ctx);
	/**
	 * Exit a parse tree produced by {@link JLEParser#arg}.
	 * @param ctx the parse tree
	 */
	void exitArg(JLEParser.ArgContext ctx);
}