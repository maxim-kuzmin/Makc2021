import { FilterProps } from 'react-table';

/**
 * Элемент управления "Текстовый фильтр".
 */
export function TextFilterControl<TRow extends object>(
  column: FilterProps<TRow>
) {
  const { filterValue, preFilteredRows, setFilter } = column;

  const count = preFilteredRows.length;

  return (
    <input
      value={filterValue || ''}
      onChange={(e) => {
        setFilter('', e.target.value || undefined); // Set undefined to remove the filter entirely
      }}
      placeholder={`Search ${count} records...`}
    />
  );
}
