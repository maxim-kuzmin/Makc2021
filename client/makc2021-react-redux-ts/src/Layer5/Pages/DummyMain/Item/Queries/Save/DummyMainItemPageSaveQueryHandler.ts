// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { HttpService } from 'src/Layer1/Http/HttpService';
import { QueryWithInputAndOutputHandler } from 'src/Layer1/Query/Handlers/QueryWithInputAndOutputHandler';
import { QueryResultWithOutput } from 'src/Layer1/Query/QueryResultWithOutput';
import { createUrlParts } from 'src/Layer1/Url/UrlParts';
import { UrlService } from 'src/Layer1/Url/UrlService';
import { Service } from 'src/Layer5/Service';
import { DummyMainItemPageSaveQueryInput } from './DummyMainItemPageSaveQueryInput';
import { DummyMainItemPageSaveQueryOutput } from './DummyMainItemPageSaveQueryOutput';

/**
 * Обработчик запроса на сохранение страницы сущности "DummyMain".
 */
export class DummyMainItemPageSaveQueryHandler extends QueryWithInputAndOutputHandler<
  DummyMainItemPageSaveQueryInput,
  DummyMainItemPageSaveQueryOutput
> {
  /**
   * Конструктор.
   * @param _appHttpService Сервис HTTP.
   * @param _appService Сервис.
   * @param _appUrlService Сервис URL.
   */
  constructor(
    private _appHttpService: HttpService,
    private _appService: Service,
    private _appUrlService: UrlService
  ) {
    super('DummyMainItemPageSaveQuery');
  }

  /**
   * Выполнить запрос.
   * @returns Обещание получения результата с выходными данными.
   */
  executeQuery(): Promise<
    QueryResultWithOutput<DummyMainItemPageSaveQueryOutput>
  > {
    const urlParts = createUrlParts();

    urlParts.path = 'pages/dummy-main/item/:queryCode';

    urlParts.params = {
      queryCode: this.queryCode
    };

    const url = this._appService.createApiUrl(
      this._appUrlService.createUrl(urlParts)
    );

    return this.queryInput.data.objectOfDummyMainEntity.id > 0
      ? this._appHttpService.put(url, this.queryInput)
      : this._appHttpService.post(url, this.queryInput);
  }
}
