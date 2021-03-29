import {
  createQueryResultWithOutput,
  QueryResultWithOutput
} from 'src/Layer1/Query/QueryResultWithOutput';
import { DummyMainItemPageGetQueryOutput } from './Queries/Get/DummyMainItemPageGetQueryOutput';

/**
 * Состояние страницы сущности "DummyMain".
 */
export interface DummyMainItemPageState {
  /**
   * Результат запроса на получение.
   */
  getQueryResult: QueryResultWithOutput<DummyMainItemPageGetQueryOutput>;

  /**
   * Признак нахождения в ожидании.
   */
  isWaiting: boolean;
}

/**
 * Создать состояние страницы сущности "DummyMain".
 * @returns Состояние страницы сущности "DummyMain".
 */
export function createDummyMainItemPageState(): DummyMainItemPageState {
  return {
    getQueryResult: createQueryResultWithOutput<DummyMainItemPageGetQueryOutput>(),
    isWaiting: false
  } as DummyMainItemPageState;
}
