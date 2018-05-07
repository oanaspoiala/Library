import * as moment from 'moment';
import * as _ from 'lodash';

export class DateUtils {
    public static dateFormat(value: string): string {
        const momentDate = moment(value);
        return momentDate.format('DD/MM/YYYY');
    }

    public static formatAllDate(value: object){
        Object.keys(value).forEach(key => {
            console.log(key);
            console.log(typeof(value[key]));
        })
    }
}