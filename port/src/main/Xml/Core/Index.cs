#region License
//
// Index.cs April 2009
//
// Copyright (C) 2009, Niall Gallagher <niallg@users.sf.net>
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or
// implied. See the License for the specific language governing
// permissions and limitations under the License.
//
#endregion
#region Using directives
using System.Collections.Generic;
using System;
#endregion
namespace SimpleFramework.Xml.Core {
   /// <summary>
   /// The <c>Index</c> object is used to represent an index
   /// of parameters iterable in declaration order. This is used so
   /// that parameters can be acquired by name for validation. It is
   /// also used to create an array of <c>Parameter</c> objects
   /// that can be used to acquire the correct deserialized values
   /// to use in order to instantiate the object.
   /// </summary>
   class Index : LinkedHashMap<String, Parameter> {
      /// <summary>
      /// This is the type that the parameters are created for.
      /// </summary>
      private readonly Class type;
      /// <summary>
      /// Constructor for the <c>Index</c> object. This is
      /// used to create a hash map that can be used to acquire
      /// parameters by name. It also provides the parameters in
      /// declaration order within a for each loop.
      /// </summary>
      /// <param name="type">
      /// this is the type the map is created for
      /// </param>
      public Index(Class type) {
         this.type = type;
      }
      /// <summary>
      /// This is used to acquire a <c>Parameter</c> using the
      /// position of that parameter within the constructor. This
      /// allows a builder to determine which parameters to use..
      /// </summary>
      /// <param name="ordinal">
      /// this is the position of the parameter
      /// </param>
      /// <returns>
      /// this returns the parameter for the position
      /// </returns>
      public Parameter GetParameter(int ordinal) {
         return Parameters.get(ordinal);
      }
      /// <summary>
      /// This is used to acquire an list of <c>Parameter</c>
      /// objects in declaration order. This list will help with the
      /// resolution of the correct constructor for deserialization
      /// of the XML. It also provides a faster method of iteration.
      /// </summary>
      /// <returns>
      /// this returns the parameters in declaration order
      /// </returns>
      public List<Parameter> Parameters {
         get {
            return new ArrayList<Parameter>(values());
         }
      }
      //public List<Parameter> GetParameters() {
      //   return new ArrayList<Parameter>(values());
      //}
      /// This is the type that this class map represents. It can be
      /// used to determine where the parameters stored are declared.
      /// </summary>
      /// <returns>
      /// returns the type that the parameters are created for
      /// </returns>
      public Class Type {
         get {
            return type;
         }
      }
      //public Class GetType() {
      //   return type;
      //}
}
