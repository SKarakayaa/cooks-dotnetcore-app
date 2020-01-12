using Castle.DynamicProxy;
using CooksProjectCore.Core.Utilities.Interceptor;
using CooksProjectCore.Core.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace CooksProjectCore.Core.Aspects.Transaction
{
    public class TransactionAspect:MethodInterception
    {
        public override void Intercept(IInvocation invocation)
        {
			using (TransactionScope transactionScope = new TransactionScope())
			{
				try
				{
					invocation.Proceed();
					transactionScope.Complete();
				}
				catch (System.Exception)
				{
					transactionScope.Dispose();
					throw new System.Exception(AspectMessages.ErrorWhileProceed);
				}
			}
			
        }
    }
}
