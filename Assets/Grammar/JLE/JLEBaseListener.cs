//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.5.3
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from JLE.g4 by ANTLR 4.5.3

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419


using Antlr4.Runtime.Misc;
using IErrorNode = Antlr4.Runtime.Tree.IErrorNode;
using ITerminalNode = Antlr4.Runtime.Tree.ITerminalNode;
using IToken = Antlr4.Runtime.IToken;
using ParserRuleContext = Antlr4.Runtime.ParserRuleContext;

/// <summary>
/// This class provides an empty implementation of <see cref="IJLEListener"/>,
/// which can be extended to create a listener which only needs to handle a subset
/// of the available methods.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.5.3")]
[System.CLSCompliant(false)]
public partial class JLEBaseListener : IJLEListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="JLEParser.start"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterStart([NotNull] JLEParser.StartContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="JLEParser.start"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitStart([NotNull] JLEParser.StartContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="JLEParser.prog"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterProg([NotNull] JLEParser.ProgContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="JLEParser.prog"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitProg([NotNull] JLEParser.ProgContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="JLEParser.function"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterFunction([NotNull] JLEParser.FunctionContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="JLEParser.function"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitFunction([NotNull] JLEParser.FunctionContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="JLEParser.function_use"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterFunction_use([NotNull] JLEParser.Function_useContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="JLEParser.function_use"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitFunction_use([NotNull] JLEParser.Function_useContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="JLEParser.function_declaration"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterFunction_declaration([NotNull] JLEParser.Function_declarationContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="JLEParser.function_declaration"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitFunction_declaration([NotNull] JLEParser.Function_declarationContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="JLEParser.param_id_list"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterParam_id_list([NotNull] JLEParser.Param_id_listContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="JLEParser.param_id_list"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitParam_id_list([NotNull] JLEParser.Param_id_listContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="JLEParser.param_decl_list"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterParam_decl_list([NotNull] JLEParser.Param_decl_listContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="JLEParser.param_decl_list"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitParam_decl_list([NotNull] JLEParser.Param_decl_listContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="JLEParser.param_decl"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterParam_decl([NotNull] JLEParser.Param_declContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="JLEParser.param_decl"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitParam_decl([NotNull] JLEParser.Param_declContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="JLEParser.param_id"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterParam_id([NotNull] JLEParser.Param_idContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="JLEParser.param_id"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitParam_id([NotNull] JLEParser.Param_idContext context) { }

	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void EnterEveryRule([NotNull] ParserRuleContext context) { }
	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void ExitEveryRule([NotNull] ParserRuleContext context) { }
	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void VisitTerminal([NotNull] ITerminalNode node) { }
	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void VisitErrorNode([NotNull] IErrorNode node) { }
}
