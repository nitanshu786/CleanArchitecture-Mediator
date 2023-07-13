import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'sorted',
  pure:false
})
export class SortedPipe implements PipeTransform {

  transform(value: number[]): number[] {
    debugger
    return value.sort((a, b) => a - b);
  }

}
