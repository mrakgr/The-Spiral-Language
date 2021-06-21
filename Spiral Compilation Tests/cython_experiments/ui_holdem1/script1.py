import logging
logging.basicConfig(
    filename='example.log',
    level=logging.DEBUG,
    datefmt='%m/%d/%Y %I:%M:%S %p',
    format='%(asctime)s %(message)s'
    )
logging.debug('This message should go to the log file')
logging.info('So should this')
logging.warning('And this, too')
logging.error('And non-ASCII stuff, too, like')