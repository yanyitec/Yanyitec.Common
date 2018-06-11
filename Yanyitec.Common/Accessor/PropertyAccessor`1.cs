using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Yanyitec.Accessor
{
    public class PropertyAccessor<T> :PropertyAccessor
        where T:class
    {
        public PropertyAccessor(MemberInfo memberInfo, IObjectAccessor<T> objectAccessor)
            :base(memberInfo,objectAccessor)
        {
            ParameterExpression objExpr = Expression.Parameter(typeof(T), "obj");
            var extractExpr = Expression.Parameter(typeof(bool), "isExtract");
            var getterLamda = Expression.Lambda<Func<T, bool, object>>(
                GenGetterExpression(memberInfo, objExpr, extractExpr, true)
                , objExpr
                , extractExpr
            );
            this.GetValue = getterLamda.Compile();

            var valueExpr = Expression.Parameter(typeof(object), "value");
            objExpr = Expression.Parameter(typeof(object), "obj");

            var setterLamda = Expression.Lambda<Action<T, object>>(
                GenSetterExpression(memberInfo, objExpr, valueExpr, true)
                , objExpr
                , valueExpr
            );
            this.SetValue = setterLamda.Compile();

        }

        public new Func<T, bool, object> GetValue { get; set; }
        public new Action<T, object> SetValue { get; set; }
    }
}
