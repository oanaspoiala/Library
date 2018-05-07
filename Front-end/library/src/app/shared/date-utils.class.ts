import * as moment from 'moment';
import * as _ from 'lodash';

export class DateUtils {
    public static dateFormat(value: string): string {
        const momentDate = moment(value);
        return momentDate.format('DD/MM/YYYY');
    }
}