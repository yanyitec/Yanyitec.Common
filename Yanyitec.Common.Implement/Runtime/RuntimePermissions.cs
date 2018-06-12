using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Yanyitec.Runtime
{
    public class RuntimePermissions : Dictionary<string, RuntimePermission>, IReadOnlyDictionary<string, IRuntimePermission>
    {
        IRuntimePermission IReadOnlyDictionary<string, IRuntimePermission>.this[string key] {
            get {
                return this[key];
            }
        }

        IEnumerable<string> IReadOnlyDictionary<string, IRuntimePermission>.Keys => this.Keys;

        IEnumerable<IRuntimePermission> IReadOnlyDictionary<string, IRuntimePermission>.Values => this.Values;

        public bool TryGetValue(string key, out IRuntimePermission value)
        {
            RuntimePermission perm = null;
            var result= base.TryGetValue(key,out perm);
            value = perm;
            return result;
        }

        IEnumerator<KeyValuePair<string, IRuntimePermission>> IEnumerable<KeyValuePair<string, IRuntimePermission>>.GetEnumerator()
        {
            return new Enumerator(base.GetEnumerator());
        }

        public class Enumerator : IEnumerator<KeyValuePair<string, IRuntimePermission>>
        {
            IEnumerator<KeyValuePair<string, RuntimePermission>> _InternalEnumerator;
            public Enumerator(IEnumerator<KeyValuePair<string, RuntimePermission>> internalEnumerator) {
                this._InternalEnumerator = internalEnumerator;
            }
            public KeyValuePair<string, IRuntimePermission> Current {
                get {
                    var pair = this._InternalEnumerator.Current;
                    return new KeyValuePair<string,IRuntimePermission>(pair.Key,pair.Value);
                }
            }

            object IEnumerator.Current => this._InternalEnumerator.Current;

            public void Dispose()
            {
                this._InternalEnumerator.Dispose();
            }

            public bool MoveNext()
            {
                return this._InternalEnumerator.MoveNext();
            }

            public void Reset()
            {
                this._InternalEnumerator.Reset();
            }
        }
    }
}
