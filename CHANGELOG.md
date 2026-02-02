# Changelog

## 6.6.0 (2026-02-02)

Full Changelog: [v6.5.1...v6.6.0](https://github.com/dodopayments/dodopayments-csharp/compare/v6.5.1...v6.6.0)

### Features

* **api:** updated openapi spec for v1.78.1 ([02f04f7](https://github.com/dodopayments/dodopayments-csharp/commit/02f04f7089195fadc2b8132c68337ce6160da496))


### Bug Fixes

* **client:** improve union equality method ([3d6ff9d](https://github.com/dodopayments/dodopayments-csharp/commit/3d6ff9d8f6aa38042322d03a3abbcbfb7f2706d9))


### Chores

* **internal:** ignore stainless-internal artifacts ([4123f78](https://github.com/dodopayments/dodopayments-csharp/commit/4123f7825ad769ee048ace66af151a5cab2697ed))

## 6.5.1 (2026-01-29)

Full Changelog: [v6.5.0...v6.5.1](https://github.com/dodopayments/dodopayments-csharp/compare/v6.5.0...v6.5.1)

### Bug Fixes

* **client:** handle unions containing unknown types properly ([0aecf3b](https://github.com/dodopayments/dodopayments-csharp/commit/0aecf3b0014b868f52c235908ad897e6a89cee98))


### Chores

* **internal:** improve HttpResponse qualification ([e4c1abb](https://github.com/dodopayments/dodopayments-csharp/commit/e4c1abba20b22fa2f3870ea0bf4be1e12c9c6649))

## 6.5.0 (2026-01-24)

Full Changelog: [v6.4.0...v6.5.0](https://github.com/dodopayments/dodopayments-csharp/compare/v6.4.0...v6.5.0)

### Features

* **client:** add `ToString` and `Equals` methods ([d5492d1](https://github.com/dodopayments/dodopayments-csharp/commit/d5492d1f3c4fbd5d54c2688698a086dfa65da110))


### Chores

* change visibility of QueryString() and AddDefaultHeaders ([8ccbc43](https://github.com/dodopayments/dodopayments-csharp/commit/8ccbc433e02c30c991ccc945c40953d5d75bd16e))

## 6.4.0 (2026-01-23)

Full Changelog: [v6.3.0...v6.4.0](https://github.com/dodopayments/dodopayments-csharp/compare/v6.3.0...v6.4.0)

### Features

* **api:** updated openapi spec to v1.75.0 ([4dc012e](https://github.com/dodopayments/dodopayments-csharp/commit/4dc012e34e9a43e260b75b46ac89dea5fdb93f61))


### Chores

* **internal:** add copy constructor tests ([33f05f4](https://github.com/dodopayments/dodopayments-csharp/commit/33f05f424751169cf6b944b84d848986fcb28461))

## 6.3.0 (2026-01-21)

Full Changelog: [v6.2.0...v6.3.0](https://github.com/dodopayments/dodopayments-csharp/compare/v6.2.0...v6.3.0)

### Features

* **api:** updated openapi spec to v1.74.0 ([2cb121b](https://github.com/dodopayments/dodopayments-csharp/commit/2cb121be07fa56f70fcecb8031d88afe6617ef6f))

## 6.2.0 (2026-01-20)

Full Changelog: [v6.1.0...v6.2.0](https://github.com/dodopayments/dodopayments-csharp/compare/v6.1.0...v6.2.0)

### Features

* **api:** update openapi spec to v1.73.0 ([d1efbe1](https://github.com/dodopayments/dodopayments-csharp/commit/d1efbe1119c2ebed9917f8c72d11c1e5a520d065))
* **client:** add `ToString` to `ApiEnum` ([a8a3151](https://github.com/dodopayments/dodopayments-csharp/commit/a8a3151b0c9fb339fb9a883f376770f74d807703))
* **client:** add Equals and ToString to params ([7350ab8](https://github.com/dodopayments/dodopayments-csharp/commit/7350ab81e367154eec076377257b529916fb0f5a))


### Chores

* **internal:** simplify imports ([906a961](https://github.com/dodopayments/dodopayments-csharp/commit/906a961f4d6f83759f88952172d7454f264b1623))
* **internal:** update `actions/checkout` version ([9a5e7f3](https://github.com/dodopayments/dodopayments-csharp/commit/9a5e7f36df6c5805f7d478b43af2aad2dc4553c1))

## 6.1.0 (2026-01-15)

Full Changelog: [v6.0.1...v6.1.0](https://github.com/dodopayments/dodopayments-csharp/compare/v6.0.1...v6.1.0)

### Features

* **client:** add helper functions for raw messages ([8bb684d](https://github.com/dodopayments/dodopayments-csharp/commit/8bb684db4d3c9f0590519e610bc19cd7d81c20e0))
* **client:** add more `ToString` implementations ([1e61d9e](https://github.com/dodopayments/dodopayments-csharp/commit/1e61d9e12bc59e51452b55af9b6b6eda2d1ce936))
* **client:** support accessing raw responses ([7109a33](https://github.com/dodopayments/dodopayments-csharp/commit/7109a337d0b49cd8ae423692981be5adaa0faf27))


### Bug Fixes

* **ci:** don't throw an error about missing lsof ([d21d53d](https://github.com/dodopayments/dodopayments-csharp/commit/d21d53db990e0566c3d61bbe4f73b33f9085da86))
* **client:** add missing serializer options ([10ca347](https://github.com/dodopayments/dodopayments-csharp/commit/10ca347178916251fe66452a5e603a483a7d6723))
* **client:** bad deserialize call for void method ([fbe39f0](https://github.com/dodopayments/dodopayments-csharp/commit/fbe39f0b74370de75adfc6246d3bbfa3e847c944))
* **client:** bad reference ([ccbc410](https://github.com/dodopayments/dodopayments-csharp/commit/ccbc41051a2fa56d61fafb5d299b6d6b96816e3b))
* **client:** copy path params in params copy constructors ([781ef5d](https://github.com/dodopayments/dodopayments-csharp/commit/781ef5d46a519cdceac9c0e03143377150f39b9f))
* **client:** ensure deep immutability for deep array/dict structures ([1f85dee](https://github.com/dodopayments/dodopayments-csharp/commit/1f85deefe4f752726b0617c33d3ec6e468ef4c9b))
* **client:** freeze models on property access ([ea9a01b](https://github.com/dodopayments/dodopayments-csharp/commit/ea9a01b832350b1669854114bc764adbc43d5ed3))
* **client:** throw api enum errors as invalid data exception ([c03f67c](https://github.com/dodopayments/dodopayments-csharp/commit/c03f67c584271ed486d0a0f729ae67fa5f2421c4))
* **client:** union switch method type checks ([c34c01d](https://github.com/dodopayments/dodopayments-csharp/commit/c34c01dc275c067def53941001e40b7ab576961c))
* **client:** use readonly type for param ([43701ac](https://github.com/dodopayments/dodopayments-csharp/commit/43701ac67dfffb6d756f7b4368a877cfc688106d))
* **internal:** remove redundant line ([1a666c2](https://github.com/dodopayments/dodopayments-csharp/commit/1a666c227ccecddf18a5d340cccf694ada81dca0))
* **internal:** remove roundtrip tests for multipart params ([46f2b9b](https://github.com/dodopayments/dodopayments-csharp/commit/46f2b9bfa4cadc1529ac3a2c231c8017fd2df70f))
* **internal:** url query param test ([e34ce0d](https://github.com/dodopayments/dodopayments-csharp/commit/e34ce0d800d078828d9b3f96b7403071ed3b58cd))


### Performance Improvements

* **client:** add json deserialization caching ([1f85dee](https://github.com/dodopayments/dodopayments-csharp/commit/1f85deefe4f752726b0617c33d3ec6e468ef4c9b))


### Chores

* **client:** consistently use serializer options ([c10f551](https://github.com/dodopayments/dodopayments-csharp/commit/c10f551496c9d7d792372162d0e61cc875a76b0f))
* **client:** refactor union instantiation ([929fa59](https://github.com/dodopayments/dodopayments-csharp/commit/929fa5997940a210503217b5eb562a2bdc6dd6f6))
* **client:** use mutable collections for union deserialization ([b57b539](https://github.com/dodopayments/dodopayments-csharp/commit/b57b53915c663d40c490ce95fa67a5785b2e47de))
* **internal:** codegen related update ([8f7f0cf](https://github.com/dodopayments/dodopayments-csharp/commit/8f7f0cfc0fe237dfc33f1aa0f107bd45dce20681))
* **readme:** remove beta warning now that we're in ga ([713f866](https://github.com/dodopayments/dodopayments-csharp/commit/713f866af1b7654e52474617e3972d2275184ff2))


### Documentation

* add raw responses to readme ([84f452f](https://github.com/dodopayments/dodopayments-csharp/commit/84f452faf222110749efd409128c480b6c5eb3f9))


### Refactors

* **client:** add `JsonDictionary` identity methods ([e9a2f37](https://github.com/dodopayments/dodopayments-csharp/commit/e9a2f3710e5ddf156a37ef02b3fdac4d663ce62e))
* **client:** make unions implement `ModelBase` ([b40b414](https://github.com/dodopayments/dodopayments-csharp/commit/b40b414a854b2961a1cd8028b77b7570b8e24139))
* **internal:** `JsonElement` constant construction ([2fcdfac](https://github.com/dodopayments/dodopayments-csharp/commit/2fcdfaceed1642563823f62002ef51e3c5977928))

## 6.0.1 (2026-01-08)

Full Changelog: [v6.0.0...v6.0.1](https://github.com/dodopayments/dodopayments-csharp/compare/v6.0.0...v6.0.1)

### Bug Fixes

* **internal:** don't try to push symbols to nuget as separate package ([f3d3bd6](https://github.com/dodopayments/dodopayments-csharp/commit/f3d3bd63338a41cef6266549f6add5fa1fada763))

## 6.0.0 (2026-01-07)

Full Changelog: [v5.2.0...v6.0.0](https://github.com/dodopayments/dodopayments-csharp/compare/v5.2.0...v6.0.0)

### ⚠ BREAKING CHANGES

* **client:** change casing of some identifiers
* **client:** **Migration:** Only use all-caps in PascalCase for two-letter acronyms. Otherwise, use a capital letter for the first letter and lowercase letters for the rest.

### Features

* **api:** updated openapi spec to v1.70.0 ([30635c6](https://github.com/dodopayments/dodopayments-csharp/commit/30635c603e7519f60938cc98d204d09ba42ef728))


### Bug Fixes

* **ci:** run tests properly on windows ([767db44](https://github.com/dodopayments/dodopayments-csharp/commit/767db441e2d46295f454444b530bacb41a58743d))
* **client:** don't dispose `HttpResponse` for methods that directly return it ([9c4c7b0](https://github.com/dodopayments/dodopayments-csharp/commit/9c4c7b0cde4878915b7fa2bd81a11c5a68bc39b6))


### Chores

* **internal:** add files to sln so they show up in visual studio ([fbcc47a](https://github.com/dodopayments/dodopayments-csharp/commit/fbcc47af92c73a669948a438f1db18adc90a4e1c))
* **internal:** codegen related update ([fa1365e](https://github.com/dodopayments/dodopayments-csharp/commit/fa1365edd377396e7fde9639c8b7435a54417e07))
* **internal:** suppress a diagnostic ([fb2639f](https://github.com/dodopayments/dodopayments-csharp/commit/fb2639fbb1ab227aef947930e7b80cb5d449bd09))
* rename some identifiers ([eada113](https://github.com/dodopayments/dodopayments-csharp/commit/eada113230cac358c6b33e6a84a040e41403d372))


### Refactors

* **client:** change casing of some identifiers ([86a2567](https://github.com/dodopayments/dodopayments-csharp/commit/86a2567794ccdccd0f45e41960d3855530e72354))

## 5.2.0 (2025-12-23)

Full Changelog: [v5.1.0...v5.2.0](https://github.com/dodopayments/dodopayments-csharp/compare/v5.1.0...v5.2.0)

### Features

* **api:** manual updates ([75d038a](https://github.com/dodopayments/dodopayments-csharp/commit/75d038af842f089ad9c90a327c8b8b7654be5641))

## 5.1.0 (2025-12-23)

Full Changelog: [v5.0.0...v5.1.0](https://github.com/dodopayments/dodopayments-csharp/compare/v5.0.0...v5.1.0)

### Features

* **api:** manual updates ([48aeaf9](https://github.com/dodopayments/dodopayments-csharp/commit/48aeaf91fded3ee9196b9b8ad73433eb5b16a400))

## 5.0.0 (2025-12-20)

Full Changelog: [v4.2.0...v5.0.0](https://github.com/dodopayments/dodopayments-csharp/compare/v4.2.0...v5.0.0)

### ⚠ BREAKING CHANGES

* **client:** add pagination

### Features

* **client:** add pagination ([7dc2e75](https://github.com/dodopayments/dodopayments-csharp/commit/7dc2e75311cee1e75232332db4ee5ccabe7a991a))


### Chores

* **internal:** turn off overzealous lints ([e319118](https://github.com/dodopayments/dodopayments-csharp/commit/e319118baed3b5ff1e41af143968700d9ae5a822))

## 4.2.0 (2025-12-19)

Full Changelog: [v4.1.0...v4.2.0](https://github.com/dodopayments/dodopayments-csharp/compare/v4.1.0...v4.2.0)

### Features

* **api:** updated openapi spec to v1.68.4 ([748a73f](https://github.com/dodopayments/dodopayments-csharp/commit/748a73f1e9ee75ae2258dd602d04bb3e528052cc))


### Bug Fixes

* **internal:** test nullability warnings ([976436a](https://github.com/dodopayments/dodopayments-csharp/commit/976436abe238715a0fd18cbc8da0247cbcc7f8b3))


### Chores

* **internal:** share csproj properties with dir build props ([976436a](https://github.com/dodopayments/dodopayments-csharp/commit/976436abe238715a0fd18cbc8da0247cbcc7f8b3))
* **internal:** use better test examples ([976436a](https://github.com/dodopayments/dodopayments-csharp/commit/976436abe238715a0fd18cbc8da0247cbcc7f8b3))

## 4.1.0 (2025-12-18)

Full Changelog: [v4.0.1...v4.1.0](https://github.com/dodopayments/dodopayments-csharp/compare/v4.0.1...v4.1.0)

### Features

* **client:** add multipart form data support ([177ae9c](https://github.com/dodopayments/dodopayments-csharp/commit/177ae9c60973d7a40c6ccaa44efc0e1351a15df5))


### Chores

* **client:** improve object instantiation ([b1048ac](https://github.com/dodopayments/dodopayments-csharp/commit/b1048acee9b31f1b06d8175fe2132cc39ecc9296))


### Documentation

* add contributing.md ([fa31911](https://github.com/dodopayments/dodopayments-csharp/commit/fa319113f3362bfe446805a31fe20be08cf72be7))

## 4.0.1 (2025-12-17)

Full Changelog: [v4.0.0...v4.0.1](https://github.com/dodopayments/dodopayments-csharp/compare/v4.0.0...v4.0.1)

### Chores

* **internal:** use `Random.Shared` in newer .NET versions ([5ceab7b](https://github.com/dodopayments/dodopayments-csharp/commit/5ceab7b013f940caf8a9a4f4a6ae91206d934a3c))

## 4.0.0 (2025-12-16)

Full Changelog: [v3.5.0...v4.0.0](https://github.com/dodopayments/dodopayments-csharp/compare/v3.5.0...v4.0.0)

### ⚠ BREAKING CHANGES

* **client:** use readonly types for properties

### Features

* **api:** manual updates ([294cd23](https://github.com/dodopayments/dodopayments-csharp/commit/294cd2345fbbbf4b61bc5a32cc32186408a86403))
* **api:** updated openapi spec to 1.67.0 ([0f5f50b](https://github.com/dodopayments/dodopayments-csharp/commit/0f5f50bb92e9ad9f57a5bfc740e037e9ad9c9701))
* **api:** updated openapi spec to v1.66.1 ([fa43768](https://github.com/dodopayments/dodopayments-csharp/commit/fa43768d2e10b0e84f314083f81f5472cd0a3aeb))
* **client:** add EnvironmentUrl ([bb6c3a0](https://github.com/dodopayments/dodopayments-csharp/commit/bb6c3a0e8257101361e191788e693688e7c99a69))
* **client:** add x-stainless-retry-count ([a06736a](https://github.com/dodopayments/dodopayments-csharp/commit/a06736a0256c59f2845348249ad8686e5751461e))
* **client:** improve csproj ([c12db18](https://github.com/dodopayments/dodopayments-csharp/commit/c12db180abbb99a8132aee8851110ea755f07537))
* **client:** improve some names ([22ef122](https://github.com/dodopayments/dodopayments-csharp/commit/22ef12235f68a5a5d2cc6b5ff017896bbd73f951))
* **client:** support .NET Standard 2.0 ([3f2a051](https://github.com/dodopayments/dodopayments-csharp/commit/3f2a0517989b438e214e3363a26b808cead26fa8))
* **internal:** add additional object tests ([90dbbd7](https://github.com/dodopayments/dodopayments-csharp/commit/90dbbd7ce30c38599dc33075f66c02454a9514bb))


### Bug Fixes

* **ci:** fail loudly if version already exists on nuget ([31bb88f](https://github.com/dodopayments/dodopayments-csharp/commit/31bb88f4d6d6439b5068b1c2724540defde60d6c))
* **client:** check response status when `MaxRetries = 0` ([59d7e66](https://github.com/dodopayments/dodopayments-csharp/commit/59d7e666d03daafe5ae6cbd759c81905553802b3))
* **client:** handling of null value type ([d6dab64](https://github.com/dodopayments/dodopayments-csharp/commit/d6dab6407901f3987384c65f49f74a5c1bcf6b83))
* **client:** support patch properly on .net standard 2.0 ([e12e6d2](https://github.com/dodopayments/dodopayments-csharp/commit/e12e6d20adf364e55a45ae5def73f424f9d500b7))
* **client:** use readonly types for properties ([fb86812](https://github.com/dodopayments/dodopayments-csharp/commit/fb868122e6b0c66faa626286b157f8ed31e031ec))
* **client:** with expressions for models ([4abebe0](https://github.com/dodopayments/dodopayments-csharp/commit/4abebe0f44355887eb92bb7fec7d6decb3fc029e))
* **internal:** add nullability checks for tests ([47ef4e6](https://github.com/dodopayments/dodopayments-csharp/commit/47ef4e60cedeccd7143340b4d513d5c9c9428953))
* **internal:** don't format csproj files ([e7b1135](https://github.com/dodopayments/dodopayments-csharp/commit/e7b113553ce8236aafad29b91217cd3a6d37dceb))
* **internal:** install csharpier during ci lint phase ([4ea571b](https://github.com/dodopayments/dodopayments-csharp/commit/4ea571ba30abaef8f4b9cff838a8839ada594f7f))
* **internal:** minor project fixes ([b7a4db6](https://github.com/dodopayments/dodopayments-csharp/commit/b7a4db6018bb73ec9b664a118a0c0b0623e817c5))
* **internal:** running net462 tests on ci ([5910683](https://github.com/dodopayments/dodopayments-csharp/commit/59106833f2bbbb0950dfc93cb2aa028468ca570f))


### Performance Improvements

* **client:** use async deserialization in `HttpResponse` ([d9dffe9](https://github.com/dodopayments/dodopayments-csharp/commit/d9dffe9597da962743f5c76985bb4402a96ea1c8))


### Chores

* **client:** improve union validation ([c98032b](https://github.com/dodopayments/dodopayments-csharp/commit/c98032b0e2014145fbf0fc017f13c394877d09af))
* **client:** update namespace imports ([3a5d519](https://github.com/dodopayments/dodopayments-csharp/commit/3a5d5194d6d9992e40b0146dee14dcd91cec509f))
* **client:** update test dependencies ([bb3dd4c](https://github.com/dodopayments/dodopayments-csharp/commit/bb3dd4c3dc6a2842a9a4d63e49835599f417ca7f))
* **internal:** add enum tests ([e6be45d](https://github.com/dodopayments/dodopayments-csharp/commit/e6be45d162c4616cb22ac8eb80a4c078fb195406))
* **internal:** add union tests ([09dafc4](https://github.com/dodopayments/dodopayments-csharp/commit/09dafc4b2bfcfb611a68bf2352a5e3bc21cfa84a))
* **internal:** codegen related update ([41947d2](https://github.com/dodopayments/dodopayments-csharp/commit/41947d2e83f9f57950b11e1212bc3f0234fd4c09))
* **internal:** equality and more unit tests ([46de49f](https://github.com/dodopayments/dodopayments-csharp/commit/46de49f810046d410aeebf98e73f83e74061e239))
* **internal:** remove redundant keyword ([19a0f99](https://github.com/dodopayments/dodopayments-csharp/commit/19a0f99ead103c11575be691bf19cf711cd5089e))
* **internal:** suppress diagnostic for .netstandard2.0 ([e8e5891](https://github.com/dodopayments/dodopayments-csharp/commit/e8e5891ae0fc6c667f9a0a4f5a6e03be273f804d))
* **internal:** update csproj formatting ([54c18d2](https://github.com/dodopayments/dodopayments-csharp/commit/54c18d25d3126661ef1ddb6252ee5fff9b3be97a))


### Documentation

* add link to nuget ([8d412c4](https://github.com/dodopayments/dodopayments-csharp/commit/8d412c46131eed498ec6b0598d8d2198891f2fca))
* add more comments ([b00c16d](https://github.com/dodopayments/dodopayments-csharp/commit/b00c16dd49b2562069c41e4c792fce4c6783223b))
* add more comments ([0fb2a10](https://github.com/dodopayments/dodopayments-csharp/commit/0fb2a10ee6854d63c60491fbec84f90721f237f9))


### Refactors

* **internal:** remove abstract static methods ([b7a08d7](https://github.com/dodopayments/dodopayments-csharp/commit/b7a08d7fe02e12c42384070a991c390fb2c21a5c))
* **internal:** share get/set logic ([d6dab64](https://github.com/dodopayments/dodopayments-csharp/commit/d6dab6407901f3987384c65f49f74a5c1bcf6b83))

## 3.5.0 (2025-11-21)

Full Changelog: [v3.4.1...v3.5.0](https://github.com/dodopayments/dodopayments-csharp/compare/v3.4.1...v3.5.0)

### Features

* **client:** additional methods for positional params ([15331e4](https://github.com/dodopayments/dodopayments-csharp/commit/15331e4aabe0c7d2df31452a274fc1da275d4811))


### Bug Fixes

* **client:** deprecate some constructors ([d10cfb4](https://github.com/dodopayments/dodopayments-csharp/commit/d10cfb437d35ed969a10e6bcc1c632e62ec2d31c))


### Chores

* **client:** change name of underlying properties for models and params ([b205887](https://github.com/dodopayments/dodopayments-csharp/commit/b2058877a601ce480dd8d3eb25caea05ea4103ec))
* **internal:** update release please config ([f6bdec8](https://github.com/dodopayments/dodopayments-csharp/commit/f6bdec85c17a371aedfa4fc06e70a248a4f1328b))


### Refactors

* **client:** make unknown variants implicit ([cb40466](https://github.com/dodopayments/dodopayments-csharp/commit/cb404662d9454041452e776aa770a276b6c1876f))

## 3.4.1 (2025-11-18)

Full Changelog: [v3.4.0...v3.4.1](https://github.com/dodopayments/dodopayments-csharp/compare/v3.4.0...v3.4.1)

### Documentation

* **internal:** add warning about implementing interface ([addd6bd](https://github.com/dodopayments/dodopayments-csharp/commit/addd6bd97265dc4d8bd6d438ea302f97bd4efbe4))

## 3.4.0 (2025-11-17)

Full Changelog: [v3.3.0...v3.4.0](https://github.com/dodopayments/dodopayments-csharp/compare/v3.3.0...v3.4.0)

### Features

* **api:** updated openapi spec to v1.61.5 ([693a3b9](https://github.com/dodopayments/dodopayments-csharp/commit/693a3b9d4d97266d354a3dc19ece9f2307ed7b79))


### Chores

* **internal:** update release please config ([8776a5e](https://github.com/dodopayments/dodopayments-csharp/commit/8776a5ea4f098ea745db6d036ff0b9454d96bfeb))

## 3.3.0 (2025-11-14)

Full Changelog: [v3.2.0...v3.3.0](https://github.com/dodopayments/dodopayments-csharp/compare/v3.2.0...v3.3.0)

### ⚠ BREAKING CHANGES

* **client:** improve names of some types

### Features

* **api:** added update payment method and updated openapi spec to v1.60.0 ([c171d40](https://github.com/dodopayments/dodopayments-csharp/commit/c171d40f4625138e0211da9e5d6f16d5ca34bde6))


### Chores

* **client:** deprecate some symbols ([3c318fb](https://github.com/dodopayments/dodopayments-csharp/commit/3c318fb56e59f6466d3aaa25bd5b8c04a91f313c))


### Documentation

* **client:** add binary responses to readme ([8c3be50](https://github.com/dodopayments/dodopayments-csharp/commit/8c3be50517a22f590a173be213f1232b67b92397))


### Refactors

* **client:** improve names of some types ([ac35743](https://github.com/dodopayments/dodopayments-csharp/commit/ac3574325038c913688cc6e36aa182cd11e7d9c6))

## 3.2.0 (2025-11-13)

Full Changelog: [v3.1.0...v3.2.0](https://github.com/dodopayments/dodopayments-csharp/compare/v3.1.0...v3.2.0)

### Features

* **client:** add `HttpResponse.ReadAsStream` method ([e17aa6b](https://github.com/dodopayments/dodopayments-csharp/commit/e17aa6b15de9cf9433cf0fc497e9dc0b925111d5))
* **client:** correct binary response methods ([c981817](https://github.com/dodopayments/dodopayments-csharp/commit/c981817345f20f34c88a14da9b2e4b59e8337a2a))


### Chores

* **internal:** codegen related update ([3fd4dba](https://github.com/dodopayments/dodopayments-csharp/commit/3fd4dba167f57ea0f4fd9f89d0fa052737372f25))


### Refactors

* **client:** move some defaults out of `ClientOptions` ([e5a513b](https://github.com/dodopayments/dodopayments-csharp/commit/e5a513b02540ecc153980b6cb3e6ef02275ccf1a))

## 3.1.0 (2025-11-12)

Full Changelog: [v3.0.0...v3.1.0](https://github.com/dodopayments/dodopayments-csharp/compare/v3.0.0...v3.1.0)

### ⚠ BREAKING CHANGES

* **client:** use `DateTimeOffset` instead of `DateTime`

### Bug Fixes

* **client:** use `DateTimeOffset` instead of `DateTime` ([c1f244e](https://github.com/dodopayments/dodopayments-csharp/commit/c1f244e8d7c91bc8a13f5e14b73d5eb2a5473192))

## 3.0.0 (2025-11-11)

Full Changelog: [v2.0.0...v3.0.0](https://github.com/dodopayments/dodopayments-csharp/compare/v2.0.0...v3.0.0)

### ⚠ BREAKING CHANGES

* **client:** flatten service namespaces
* **client:** interpret null as omitted in some properties

### Features

* **client:** add cancellation token support ([8c09a8f](https://github.com/dodopayments/dodopayments-csharp/commit/8c09a8ff91dc2ab486c485c53b135ef48452b385))
* **client:** add retries support ([3b9b3e5](https://github.com/dodopayments/dodopayments-csharp/commit/3b9b3e5bc7887b2168237cf973b90e4e82b9176b))
* **client:** add some implicit operators ([dd2d916](https://github.com/dodopayments/dodopayments-csharp/commit/dd2d916973fe19e0f0c237cb158dc16128db6230))
* **client:** send `User-Agent` header ([86c07b4](https://github.com/dodopayments/dodopayments-csharp/commit/86c07b451e3324714f68ce75acbfd2374c63d0c7))
* **client:** send `X-Stainless-Arch` header ([5088b4e](https://github.com/dodopayments/dodopayments-csharp/commit/5088b4e6736d5dc0bbad4f44d74a0f48073e9a3d))
* **client:** send `X-Stainless-Lang` and `X-Stainless-OS` headers ([ea66424](https://github.com/dodopayments/dodopayments-csharp/commit/ea66424db67601c1a73ad8863e285226c4da4865))
* **client:** send `X-Stainless-Package-Version` headers ([e2a99e3](https://github.com/dodopayments/dodopayments-csharp/commit/e2a99e3d76ab389aac30fc1c88bb3ba5a0fc5d6d))
* **client:** send `X-Stainless-Runtime` and `X-Stainless-Runtime-Version` ([48fb647](https://github.com/dodopayments/dodopayments-csharp/commit/48fb647633f9905e042dee13815171ef6486918d))
* **client:** send `X-Stainless-Timeout` header ([6ba270c](https://github.com/dodopayments/dodopayments-csharp/commit/6ba270c6fdf6e0db8ddd38eaf0ccd658ab484f78))


### Bug Fixes

* **client:** interpret null as omitted in some properties ([272fe1b](https://github.com/dodopayments/dodopayments-csharp/commit/272fe1b7a93877d89bc30cd0421e12000484a525))


### Performance Improvements

* **client:** optimize header creation ([5893a7b](https://github.com/dodopayments/dodopayments-csharp/commit/5893a7ba52b150d6cc42c8cbbeaeeed4e7cc9561))


### Chores

* **internal:** add prism log file to gitignore ([ebf28cb](https://github.com/dodopayments/dodopayments-csharp/commit/ebf28cb2083cbf861c7034af2cfe6a2e2c844f34))
* **internal:** delete empty test files ([2afba4b](https://github.com/dodopayments/dodopayments-csharp/commit/2afba4b913697f74e81e61fd143dcd26d473f88c))
* **internal:** improve devcontainer ([4728883](https://github.com/dodopayments/dodopayments-csharp/commit/4728883a3f9f0e61225a9153e95a3f5d1b245fb4))
* **internal:** minor improvements to csproj and gitignore ([38e62b3](https://github.com/dodopayments/dodopayments-csharp/commit/38e62b35e7e50cd2ad21be66b6a20daeeac8184d))
* **internal:** reduce import qualification ([7bedcb9](https://github.com/dodopayments/dodopayments-csharp/commit/7bedcb971368f7cffa28e45e00195ce291396af6))


### Documentation

* **client:** document max retries ([16753dc](https://github.com/dodopayments/dodopayments-csharp/commit/16753dc0df78248bde16171cec397eb19c2c9c7d))
* **client:** separate comment content into paragraphs ([bc031ba](https://github.com/dodopayments/dodopayments-csharp/commit/bc031baadf8bb0d06fb86e08f7b903199ac710e5))


### Refactors

* **client:** flatten service namespaces ([69967c7](https://github.com/dodopayments/dodopayments-csharp/commit/69967c7987a0e2c4e0d528df6450a655a970a835))
* **client:** pass around `ClientOptions` instead of client ([1d999b8](https://github.com/dodopayments/dodopayments-csharp/commit/1d999b869ecf38756098a8c54c40c90dd5f7c015))

## 2.0.0 (2025-11-07)

Full Changelog: [v1.56.5...v2.0.0](https://github.com/dodopayments/dodopayments-csharp/compare/v1.56.5...v2.0.0)

### ⚠ BREAKING CHANGES

* **client:** make models immutable

### Features

* **client:** make models immutable ([3de9b83](https://github.com/dodopayments/dodopayments-csharp/commit/3de9b8365b026b52aeae0988f9e0128d57d696c4))


### Chores

* **internal:** codegen related update ([f716c6a](https://github.com/dodopayments/dodopayments-csharp/commit/f716c6a766c270a25bfff809df27b9f8ae9bc78c))


### Documentation

* **client:** document response validation ([8a7df74](https://github.com/dodopayments/dodopayments-csharp/commit/8a7df742b4a29cd0666b47def93866f1129a1414))
* **client:** improve snippet formatting ([85652c6](https://github.com/dodopayments/dodopayments-csharp/commit/85652c6e5a9b9bebbf662e47fd355b0acf8d0ede))

## 1.56.5 (2025-11-05)

Full Changelog: [v1.56.4...v1.56.5](https://github.com/dodopayments/dodopayments-csharp/compare/v1.56.4...v1.56.5)

### Features

* **client:** add response validation option ([e957c47](https://github.com/dodopayments/dodopayments-csharp/commit/e957c47f373a266473384cf28ed2b891e51dbcc6))
* **client:** add support for option modification ([fe0779d](https://github.com/dodopayments/dodopayments-csharp/commit/fe0779d19e448cf5e9692b6528730e1b66c8be2b))
* **client:** support request timeout ([aa371e2](https://github.com/dodopayments/dodopayments-csharp/commit/aa371e2dcd0fbb3d73ee3ddfcea3968b45194f53))


### Chores

* **client:** simplify field validations ([e957c47](https://github.com/dodopayments/dodopayments-csharp/commit/e957c47f373a266473384cf28ed2b891e51dbcc6))
* **internal:** extract `ClientOptions` struct ([84175d2](https://github.com/dodopayments/dodopayments-csharp/commit/84175d29efc473f90cfd6f7f5794fb5d31a76fd0))


### Documentation

* **client:** document `WithOptions` ([73b8ad4](https://github.com/dodopayments/dodopayments-csharp/commit/73b8ad484616bb79e4311d508476ea1644b51345))
* **client:** document timeout option ([0016a5e](https://github.com/dodopayments/dodopayments-csharp/commit/0016a5e4e2949b1b2c833e1a6704a1ab3d72072f))

## 1.56.4 (2025-10-31)

Full Changelog: [v1.56.3...v1.56.4](https://github.com/dodopayments/dodopayments-csharp/compare/v1.56.3...v1.56.4)

### Chores

* **internal:** full qualify some references ([3a41f8c](https://github.com/dodopayments/dodopayments-csharp/commit/3a41f8c1515eec97d411a05ebae8a48d9143f870))

## 1.56.3 (2025-10-29)

Full Changelog: [v1.56.2...v1.56.3](https://github.com/dodopayments/dodopayments-csharp/compare/v1.56.2...v1.56.3)

### Features

* **api:** updated openapi spec to v1.56.3 ([52b3c00](https://github.com/dodopayments/dodopayments-csharp/commit/52b3c0063f0c2217103417244905a435442d49cd))


### Bug Fixes

* **internal:** minor bug fixes on model instantiation and union validation ([f6abc5c](https://github.com/dodopayments/dodopayments-csharp/commit/f6abc5c7889f657ce5020ceca60645778c91ed42))

## 1.56.2 (2025-10-27)

Full Changelog: [v1.56.0...v1.56.2](https://github.com/dodopayments/dodopayments-csharp/compare/v1.56.0...v1.56.2)

### Features

* **api:** updated to openapi spec v1.56.0 ([39b3ea0](https://github.com/dodopayments/dodopayments-csharp/commit/39b3ea0cec191a5cbaef547795446f2b0764446f))

## 1.56.0 (2025-10-25)

Full Changelog: [v1.55.7...v1.56.0](https://github.com/dodopayments/dodopayments-csharp/compare/v1.55.7...v1.56.0)

### Features

* **api:** added unwrap functions for webhooks ([b1396e8](https://github.com/dodopayments/dodopayments-csharp/commit/b1396e8a57f690da8e69408938f4fee1b54396bc))

## 1.55.7 (2025-10-17)

Full Changelog: [v1.55.3...v1.55.7](https://github.com/dodopayments/dodopayments-csharp/compare/v1.55.3...v1.55.7)

### Features

* **api:** updates for openapi spec v1.55.7 ([d625c98](https://github.com/dodopayments/dodopayments-csharp/commit/d625c98a75a396396f468114c7ab96d769dfe7f3))

## 1.55.3 (2025-10-16)

Full Changelog: [v1.55.0...v1.55.3](https://github.com/dodopayments/dodopayments-csharp/compare/v1.55.0...v1.55.3)

### Features

* **api:** updated openapi spec to v1.55.0 ([9ea3e6d](https://github.com/dodopayments/dodopayments-csharp/commit/9ea3e6d650931f45bb09c04cf60f8c45c418c072))

## 1.55.0 (2025-10-08)

Full Changelog: [v1.54.0...v1.55.0](https://github.com/dodopayments/dodopayments-csharp/compare/v1.54.0...v1.55.0)

### Features

* **client:** refactor unions ([d446524](https://github.com/dodopayments/dodopayments-csharp/commit/d44652418967544a0ac12b04d46ca7f805ad6ee6))
* **internal:** add dev container ([5031f27](https://github.com/dodopayments/dodopayments-csharp/commit/5031f2786d3bbe930b66c903526e41e2e8fbc495))


### Chores

* **internal:** restructure some imports ([79c36a8](https://github.com/dodopayments/dodopayments-csharp/commit/79c36a80f5e403d22d0483847c471b147f8168f7))

## 1.54.0 (2025-10-02)

Full Changelog: [v1.53.3...v1.54.0](https://github.com/dodopayments/dodopayments-csharp/compare/v1.53.3...v1.54.0)

### Features

* **client:** refactor exceptions ([0402f73](https://github.com/dodopayments/dodopayments-csharp/commit/0402f73af868dda1fd24581a591bf1feb1e6ce38))

## 1.53.3 (2025-09-23)

Full Changelog: [v1.53.2...v1.53.3](https://github.com/dodopayments/dodopayments-csharp/compare/v1.53.2...v1.53.3)

### Bug Fixes

* **internal:** remove example csproj ([323eee8](https://github.com/dodopayments/dodopayments-csharp/commit/323eee83d197cf7d11b07fdf6a4977137324973d))


### Chores

* improve example values ([2960a13](https://github.com/dodopayments/dodopayments-csharp/commit/2960a13633b8fba259e461af2290ad9c6f10de3f))
* **internal:** codegen related update ([4c3d114](https://github.com/dodopayments/dodopayments-csharp/commit/4c3d114dc67088c5fff7c4409a1692eb6c47b7c1))

## 1.53.2 (2025-09-17)

Full Changelog: [v1.53.0...v1.53.2](https://github.com/dodopayments/dodopayments-csharp/compare/v1.53.0...v1.53.2)

### Features

* **api:** manual updates ([4d11d94](https://github.com/dodopayments/dodopayments-csharp/commit/4d11d9447487ac03e5bff0eea2cba33ddcdb7588))

## 1.53.0 (2025-09-17)

Full Changelog: [v0.0.1...v1.53.0](https://github.com/dodopayments/dodopayments-csharp/compare/v0.0.1...v1.53.0)

### Features

* **api:** manual updates ([38f315f](https://github.com/dodopayments/dodopayments-csharp/commit/38f315f7b6881d924ab87eaf12a00b684e1fcefb))


### Chores

* configure new SDK language ([4110e68](https://github.com/dodopayments/dodopayments-csharp/commit/4110e685e84001c605d09717a6d8d487cc55f32a))
* update SDK settings ([e57f897](https://github.com/dodopayments/dodopayments-csharp/commit/e57f8972652efd9667970124aee3a66929b870b5))
