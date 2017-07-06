// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Class1.cs" company="">
//   
// </copyright>
// <summary>
//   The class 1.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace StyleCopLearn
{
    using StyleCop;
    using StyleCop.CSharp;

    /// <summary>
    /// The class 1.
    /// </summary>
    [SourceAnalyzer(typeof(CsParser))]
    public class GetStudent : SourceAnalyzer
    {
        #region Public Methods and Operators

        /// <summary>
        /// Extremely simple analyzer for demo purposes.  
        /// </summary>
        /// <param name="document">
        /// The document.
        /// </param>
        public override void AnalyzeDocument(CodeDocument document)
        {
            CsDocument doc = (CsDocument)document;

            // skipping wrong or auto-generated documents  
            if (doc.RootElement == null || doc.RootElement.Generated)
            {
                return;
            }

            // check all class entries  
            doc.WalkDocument(this.CheckClasses);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Checks whether specified element conforms custom rule CR0001.  
        /// </summary>
        /// <param name="element">
        /// The element.
        /// </param>
        /// <param name="parentElement">
        /// The parent Element.
        /// </param>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool CheckClasses(CsElement element, CsElement parentElement, object context)
        {
            if (element.ElementType != ElementType.Class)
            {
                return true;
            }

            Class classElement = (Class)element;
            if (classElement.Declaration.Name.Contains("a"))
            {
                this.AddViolation(
                    classElement, classElement.Location, "AvoidUsingAInClassNames", classElement.FriendlyTypeText);
            }

            return true;
        }

        #endregion
    }
}