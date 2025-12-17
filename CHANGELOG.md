# Changelog

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
