﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Elastic.Xunit.XunitPlumbing;
using Nest;

namespace Tests.Analysis.CharFilters
{
	public interface ICharFilterAssertion : IAnalysisAssertion<ICharFilter, ICharFilters, CharFiltersDescriptor> { }

	public abstract class CharFilterAssertionBase<TAssertion>
		: AnalysisComponentTestBase<TAssertion, ICharFilter, ICharFilters, CharFiltersDescriptor>
			, ICharFilterAssertion
		where TAssertion : CharFilterAssertionBase<TAssertion>, new()
	{
		protected override IAnalysis FluentAnalysis(AnalysisDescriptor an) =>
			an.CharFilters(d => AssertionSetup.Fluent(AssertionSetup.Name, d));

		protected override Nest.Analysis InitializerAnalysis() =>
			new Nest.Analysis {CharFilters = new Nest.CharFilters {{AssertionSetup.Name, AssertionSetup.Initializer}}};

		protected override object AnalysisJson => new
		{
			char_filter = new Dictionary<string, object> { {AssertionSetup.Name, AssertionSetup.Json} }
		};
		// https://youtrack.jetbrains.com/issue/RIDER-19912
		[U] public override Task TestPutSettingsRequest() => base.TestPutSettingsRequest();
		[I] public override Task TestPutSettingsResponse() => base.TestPutSettingsResponse();
	}
}
