//
// CodeDelegateCreateExpressionTest.cs
//	- Unit tests for System.CodeDom.CodeDelegateCreateExpression
//
// Author:
//	Gert Driesen  <drieseng@users.sourceforge.net>
//
// Copyright (C) 2005 Novell, Inc (http://www.novell.com)
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//

using NUnit.Framework;

using System;
using System.CodeDom;

namespace MonoTests.System.CodeDom
{
	[TestFixture]
	public class CodeDelegateCreateExpressionTest
	{
		[Test]
		public void Constructor0 ()
		{
			CodeDelegateCreateExpression cdce = new CodeDelegateCreateExpression ();

			Assert.IsNotNull (cdce.DelegateType, "#1");
			Assert.AreEqual (typeof (void).FullName, cdce.DelegateType.BaseType, "#2");
			Assert.IsNotNull (cdce.MethodName, "#3");
			Assert.AreEqual (string.Empty, cdce.MethodName, "#4");
			Assert.IsNull (cdce.TargetObject, "#5");

			CodeTypeReference type = new CodeTypeReference ("mono");
			cdce.DelegateType = type;
			Assert.IsNotNull (cdce.DelegateType, "#6");
			Assert.AreSame (type, cdce.DelegateType, "#7");

			cdce.DelegateType = null;
			Assert.IsNotNull (cdce.DelegateType, "#8");
			Assert.AreEqual (typeof (void).FullName, cdce.DelegateType.BaseType, "#9");

			cdce.MethodName = null;
			Assert.IsNotNull (cdce.MethodName, "#10");
			Assert.AreEqual (string.Empty, cdce.MethodName, "#11");

			CodeExpression expression = new CodeExpression ();
			cdce.TargetObject = expression;
			Assert.IsNotNull (cdce.TargetObject, "#12");
			Assert.AreSame (expression, cdce.TargetObject, "#13");

			cdce.TargetObject = null;
			Assert.IsNull (cdce.TargetObject, "#14");
		}

		[Test]
		public void Constructor1 ()
		{
			CodeExpression expression = new CodeExpression ();
			CodeTypeReference type = new CodeTypeReference ("mono");
			string methodName = "mono";

			CodeDelegateCreateExpression cdce = new CodeDelegateCreateExpression (
				type, expression, methodName);

			Assert.IsNotNull (cdce.DelegateType, "#1");
			Assert.AreSame (type, cdce.DelegateType, "#2");
			Assert.IsNotNull (cdce.MethodName, "#3");
			Assert.AreSame (methodName, cdce.MethodName, "#4");
			Assert.IsNotNull (cdce.TargetObject, "#5");
			Assert.AreSame (expression, cdce.TargetObject, "#6");

			cdce = new CodeDelegateCreateExpression ((CodeTypeReference) null,
				(CodeExpression) null, (string) null);

			Assert.IsNotNull (cdce.DelegateType, "#7");
			Assert.AreEqual (typeof (void).FullName, cdce.DelegateType.BaseType, "#8");
			Assert.IsNotNull (cdce.MethodName, "#9");
			Assert.AreEqual (string.Empty, cdce.MethodName, "#10");
			Assert.IsNull (cdce.TargetObject, "#11");
		}
	}
}
