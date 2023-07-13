import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'orderBy',
  pure: true
})
export class OrderByPipe implements PipeTransform {

  transform(array: any[], property: string): any[] {
    debugger
    if (!Array.isArray(array)) {
      return array;
    }
    return array.sort((a, b) => {
      debugger
      if (a[property] < b[property]) {
        return -1;
      } else if (a[property] > b[property]) {
        return 1;
      } else {
        return 0;
      }
    });
  }
}
