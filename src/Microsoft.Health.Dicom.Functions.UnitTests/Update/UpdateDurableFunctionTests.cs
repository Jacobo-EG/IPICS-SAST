// -------------------------------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See LICENSE in the repo root for license information.
// -------------------------------------------------------------------------------------------------

using System.Text.Json;
using Microsoft.Extensions.Options;
using Microsoft.Health.Dicom.Core.Features.Common;
using Microsoft.Health.Dicom.Core.Features.Retrieve;
using Microsoft.Health.Dicom.Core.Features.Store;
using Microsoft.Health.Dicom.Core.Features.Update;
using Microsoft.Health.Dicom.Functions.Update;
using Microsoft.Health.Operations.Functions.DurableTask;
using NSubstitute;

namespace Microsoft.Health.Dicom.Functions.UnitTests.Update;

public partial class UpdateDurableFunctionTests
{
    private readonly UpdateDurableFunction _updateDurableFunction;
    private readonly IIndexDataStore _indexStore;
    private readonly IInstanceStore _instanceStore;
    private readonly UpdateOptions _options;
    private readonly IMetadataStore _metadataStore;
    private readonly IFileStore _fileStore;
    private readonly IUpdateInstanceService _updateInstanceService;
    private readonly JsonSerializerOptions _jsonSerializerOptions;

    public UpdateDurableFunctionTests()
    {
        _indexStore = Substitute.For<IIndexDataStore>();
        _instanceStore = Substitute.For<IInstanceStore>();
        _metadataStore = Substitute.For<IMetadataStore>();
        _fileStore = Substitute.For<IFileStore>();
        _updateInstanceService = Substitute.For<IUpdateInstanceService>();
        _options = new UpdateOptions { RetryOptions = new ActivityRetryOptions() };
        _jsonSerializerOptions = new JsonSerializerOptions();
        _updateDurableFunction = new UpdateDurableFunction(
            _indexStore,
            _instanceStore,
            Options.Create(_options),
            _metadataStore,
            _fileStore,
            _updateInstanceService,
            Options.Create(_jsonSerializerOptions));
    }
}