import * as moment from 'moment';
import * as _ from 'lodash';
import { DMY } from '.';

export class DateUtils {
    public static dateFormat(value: string): string {
        const momentDate = moment(value);
        return momentDate.format('DD/MM/YYYY');
    }

    public static formatAllDate(value: object) {
        Object.keys(value).forEach(key => {
            console.log(key);
            console.log(typeof(value[key]));
        });
    }

    public static dateToDmy(value: any): DMY {
        const momentDate = moment(value);
        const result: DMY = {
            year: +momentDate.format('YYYY'),
            month: +momentDate.format('MM'),
            day: +momentDate.format('DD')
        };
        return result;
    }

    public static dmyToDate(value: DMY): any {
        const date = new Date(`${value.year}-${value.month}-${value.day}`);
        return moment(date);
    }
}
