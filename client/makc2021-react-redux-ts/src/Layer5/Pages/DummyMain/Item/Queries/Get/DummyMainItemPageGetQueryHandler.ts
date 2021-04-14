// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { HttpService } from 'src/Layer1/Http/HttpService';
import { QueryWithInputAndOutputHandler } from 'src/Layer1/Query/Handlers/QueryWithInputAndOutputHandler';
import { QueryResultWithOutput } from 'src/Layer1/Query/QueryResultWithOutput';
import { createUrlParts } from 'src/Layer1/Url/UrlParts';
import { UrlService } from 'src/Layer1/Url/UrlService';
import { Service } from 'src/Layer5/Service';
import { DummyMainItemPageGetQueryInput } from './DummyMainItemPageGetQueryInput';
import { DummyMainItemPageGetQueryOutput } from './DummyMainItemPageGetQueryOutput';

/**
 * Обработчик запроса на получение страницы сущности "DummyMain".
 */
export class DummyMainItemPageGetQueryHandler extends QueryWithInputAndOutputHandler<
  DummyMainItemPageGetQueryInput,
  DummyMainItemPageGetQueryOutput
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
    super('DummyMainItemPageGetQuery');
  }

  /**
   * Выполнить запрос.
   * @returns Обещание получения результата с выходными данными.
   */
  executeQuery(): Promise<
    QueryResultWithOutput<DummyMainItemPageGetQueryOutput>
  > {
    const urlParts = createUrlParts();

    urlParts.path = 'pages/dummy-main/item/:queryCode/:entityId';

    const { entityId } = this.queryInput.item;

    urlParts.params = {
      queryCode: this.queryCode,
      entityId
    };

    const url = this._appService.createApiUrl(
      this._appUrlService.createUrl(urlParts)
    );

    return this._appHttpService.get(url);
  }
}
