import { QueryResultWithOutput } from 'src/Layer1/Query/QueryResultWithOutput';
import { DummyMainItemPageGetQueryOutput } from '../Queries/Get/DummyMainItemPageGetQueryOutput';
import { DummyMainItemPageSaveQueryInput } from '../Queries/Save/DummyMainItemPageSaveQueryInput';

/**
 * Полезная нагрузка для действия сохранения в хранилище страницы сущности "DummyMain".
 */
export interface DummyMainItemPageStorePayloadForSave {
  /**
   * Входные данные запроса на сохранение.
   */
  saveQueryInput: DummyMainItemPageSaveQueryInput;
  /**
   * Результат запроса на получение.
   */
  getQueryResult: QueryResultWithOutput<DummyMainItemPageGetQueryOutput>;
}

/**
 * Создать полезную нагрузку для действия сохранения в хранилище страницы примера элемента.
 * @param saveQueryInput Входные данные запроса на сохранение.
 * @param getQueryResult Результат запроса на получение.
 * @returns Полезная нагрузка для действия сохранения в хранилище страницы примера элемента.
 */
export function createDummyMainItemPageStorePayloadForSave(
  saveQueryInput: DummyMainItemPageSaveQueryInput,
  getQueryResult: QueryResultWithOutput<DummyMainItemPageGetQueryOutput>
) {
  return {
    saveQueryInput,
    getQueryResult
  } as DummyMainItemPageStorePayloadForSave;
}
