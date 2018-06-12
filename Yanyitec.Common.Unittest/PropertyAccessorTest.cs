using System;
using Xunit;
using Yanyitec.Unittest.Entities;
using Yanyitec.Accessor;

namespace Yanyitec.Unittest
{
    public class PropertyAccessorUnittest
    {
        
        [Fact]
        public void GetSetProp()
        {
            var idProp = typeof(User).GetProperty("Id");
            var memberAccessor = new PropertyAccessor(idProp,null);
            Assert.False(memberAccessor.IsNullable);
            Assert.Equal(typeof(int), memberAccessor.EntitativeType);

            var obj = new User() { Id = 2 };
            memberAccessor.SetValue(obj,3);
            Assert.Equal(3, obj.Id);
            var value = memberAccessor.GetValue(obj,false);
            Assert.Equal(3,(int)value);
            
        }
        [Fact]
        public void GetSetNullable()
        {
            var idProp = typeof(User).GetProperty("Age");
            var memberAccessor = new PropertyAccessor(idProp, null);
            Assert.True(memberAccessor.IsNullable);
            Assert.Equal(typeof(int),memberAccessor.EntitativeType);

            var obj = new User() { Id = 2 };
            memberAccessor.SetValue(obj,new Nullable<int>(3));
            Assert.Equal(new Nullable<int>(3),obj.Age);
            var value = memberAccessor.GetValue(obj, false);
            Assert.Equal(new Nullable<int>(3), (Nullable<int>)value);

            memberAccessor.SetValue(obj, 5);
            Assert.Equal(new Nullable<int>(5), obj.Age);

            var value1 = memberAccessor.GetValue(obj, true);
            Assert.Equal(5, (int)value1);

        }
    }
}
