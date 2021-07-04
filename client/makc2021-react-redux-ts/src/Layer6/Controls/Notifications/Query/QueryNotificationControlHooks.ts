import { useContext, useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { Context } from 'src/Context';
import { QueryResult } from 'src/Layer1/Query/QueryResult';

/**
 * Использовать извещение запроса.
 * @param queryResult Результат запроса.
 */
export function useQueryNotification(queryResult: QueryResult) {
  const contextValue = useContext(Context);

  const store = contextValue.Layer5.Controls.Notifications.Query.getModule()
    .store;

  const dispatch = useDispatch();

  const queryResults = useSelector(store.selectQueryResults);

  useEffect(() => {
    if (
      !queryResults.some(
        (existingQueryResult) =>
          existingQueryResult.queryCode === queryResult.queryCode
      )
    ) {
      dispatch(store.addQueryResultAsync(queryResult));
    }
  }, [queryResult?.queryCode, dispatch, queryResults, store, queryResult]);
}
